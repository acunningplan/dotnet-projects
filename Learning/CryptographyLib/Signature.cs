using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

namespace CryptographyLib
{
    public static class Signature
    {
        public static string PublicKey;
        public static string GenerateSignature(string data)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);
            var rsa = RSA.Create();
            PublicKey = rsa.ToXmlStringExt(false);  // exclude private key 
            return ToBase64String(rsa.SignHash(hashedData, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
        }
        public static bool ValidateSignature(string data, string signature)
        {
            byte[] dataBytes = Encoding.Unicode.GetBytes(data);
            var sha = SHA256.Create();
            var hashedData = sha.ComputeHash(dataBytes);
            byte[] signatureBytes = FromBase64String(signature);
            var rsa = RSA.Create();
            rsa.FromXmlStringExt(PublicKey);
            return rsa.VerifyHash(hashedData, signatureBytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
        }
        // custom implementation of serialization and deserialization
        public static string ToXmlStringExt(this RSA rsa, bool includePrivateParameters)
        {
            var p = rsa.ExportParameters(includePrivateParameters);
            XElement xml;
            if (includePrivateParameters)
            {
                xml = new XElement("RSAKeyValue",
                    new XElement("Modulus", ToBase64String(p.Modulus)),
                    new XElement("Exponent", ToBase64String(p.Exponent)),
                    new XElement("P", ToBase64String(p.P)),
                    new XElement("Q", ToBase64String(p.Q)),
                    new XElement("DP", ToBase64String(p.DP)),
                    new XElement("DQ", ToBase64String(p.DQ)),
                    new XElement("InverseQ", ToBase64String(p.InverseQ)));
            }
            else
            {
                xml = new XElement("RSAKeyValue",
                    new XElement("Modulus", ToBase64String(p.Modulus)),
                    new XElement("Exponent", ToBase64String(p.Exponent)));
            }
            return xml?.ToString();
        }
        public static void FromXmlStringExt(this RSA rsa, string parametersAsXml)
        {
            var xml = XDocument.Parse(parametersAsXml);


            var root = xml.Element("RSAKeyValue");
            var p = new RSAParameters
            {
                Modulus = FromBase64String(root.Element("Modulus").Value),
                Exponent = FromBase64String(root.Element("Exponent").Value)
            };
            if (root.Element("P") != null)
            {
                p.P = FromBase64String(root.Element("P").Value);
                p.Q = FromBase64String(root.Element("Q").Value);
                p.DP = FromBase64String(root.Element("DP").Value);
                p.DQ = FromBase64String(root.Element("DQ").Value);
                p.InverseQ = FromBase64String(root.Element("InverseQ").Value);
            }
            rsa.ImportParameters(p);
        }

    }
}
