using System.Security.Cryptography;
using System.Text;

namespace finalProject.Common.Secure.Hashing
{
    public static class HashGenerator
    {
        public static void GeneratePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new();
            passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            passwordSalt = hmac.Key;
        }

        public static bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using HMACSHA512 hmac = new(passwordSalt);
            byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
