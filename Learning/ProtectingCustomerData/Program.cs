using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;
using static System.IO.Path;
using static System.Environment;
using static System.Console;
using static System.Convert;
using System.Security.Cryptography;
using System.Text;

namespace ProtectingCustomerData
{
    class Program
    {

        static void Main(string[] args)
        {
            List<Customer> Customers = new List<Customer>();
            Customers.Add(new Customer
            {
                Name = "James Leung",
                CreditCard = "3333-3333-3333-3333",
                Password = "Beat back the normies"
            });
            Customers.Add(new Customer
            {
                Name = "Zoe Tyler",
                CreditCard = "3333-4444-5555-6666",
                Password = "Life is okay"
            });

            List<Customer> SecureCustomers = new List<Customer>();
            // generate salt and hash the passwords
            foreach (Customer customer in Customers)
            {
                SecureCustomers.Add(
                    new Customer
                    {
                        Name = customer.Name,
                        CreditCard = Encrypt(customer.CreditCard, customer.Password),
                        Password = Hash(customer.Password)
                    });
            }

            var serializerXml = new XmlSerializer(typeof(List<Customer>));
            string path = Combine(CurrentDirectory, "credit-card-numbers.xml");
            using (FileStream stream = File.Create(path))
            {
                serializerXml.Serialize(stream, SecureCustomers);
            }

            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                List<Customer> loadedShapesXml = serializerXml.Deserialize(stream) as List<Customer>;
                foreach (Customer desCustomer in loadedShapesXml)
                {
                    Customer customer = Customers.Find(customer => customer.Name == desCustomer.Name);
                    WriteLine("{0} {1} has credit card number: {2}", desCustomer.GetType().Name, desCustomer.Name, Decrypt(desCustomer.CreditCard, customer.Password));
                };
            }
        }

        public static string Hash(string password)
        {
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = ToBase64String(saltBytes);

            var sha = SHA256.Create();
            var saltedPassword = password + saltText;
            return ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }

        private static readonly byte[] salt = Encoding.Unicode.GetBytes("wortwortwort");
        private static readonly int iterations = 2000;
        public static string Encrypt(string plainText, string password)
        {
            byte[] encryptedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32); // set a 256-bit key 
            aes.IV = pbkdf2.GetBytes(16); // set a 128-bit IV  
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encryptedBytes = ms.ToArray();
            }
            return ToBase64String(encryptedBytes);
        }

        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = FromBase64String(cryptoText);
            var aes = Aes.Create();
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }
            return Encoding.Unicode.GetString(plainBytes);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string CreditCard { get; set; }
        public string Password { get; set; }
    }
}
