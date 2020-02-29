using System.Security.Cryptography;

namespace CryptographyLib
{
    public class RandomKeyOrIv
    {
        public static byte[] GetRandomKeyOrIv(int size)
        {
            var r = RandomNumberGenerator.Create();
            var data = new byte[size];
            r.GetNonZeroBytes(data);
            return data;
        }
    }
}
