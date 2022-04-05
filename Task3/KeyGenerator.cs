using System.Security.Cryptography;
using System.Text;

namespace Task3
{
    internal class KeyGenerator
    {
        public static byte[] generateSecretKey(int size)
        {
            using (var generator = RandomNumberGenerator.Create())
            {
                var key = new byte[size];
                generator.GetBytes(key);
                return key;
            }
        }

        public static int generateMove(int numberOfMoves)
        {
            Random random = new Random();
            return random.Next(numberOfMoves);
        }

        public static byte[] generateHMAC(byte[] key, string move)
        {
            using (HMACSHA256 sha256 = new HMACSHA256(key))
            {
                byte[] hmac = sha256.ComputeHash(Encoding.Default.GetBytes(move));
                return hmac;
            }
        }

    }
}
