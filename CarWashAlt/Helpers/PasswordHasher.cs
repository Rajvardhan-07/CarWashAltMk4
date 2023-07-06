using System.Security.Cryptography;

namespace CarWashAlt.Helpers
{
    public class PasswordHasher
    {
        private static RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        private static readonly int SaltSize = 16;
        private static readonly int HashSize = 20;
        private static readonly int Iterations = 10000;

        #region Creating Hash Of Password

        public static string HashPassword(string password)
        {
            byte[] salt;
            rng.GetBytes(salt = new byte[SaltSize]);
            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            var hash = key.GetBytes(HashSize);

            var hasBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hasBytes, 0, SaltSize);
            Array.Copy(hash, 0, hasBytes, SaltSize, HashSize);

            var base64Hash = Convert.ToBase64String(hasBytes);

            return base64Hash;
        }


        #endregion Creating Hash Of Password


        #region Verifying Password Is Valid 
        public static bool VerifyPassword(string password, string bas64Hash)
        {
            var hasBytess = Convert.FromBase64String(bas64Hash);
            var salt = new byte[SaltSize];
            Array.Copy(hasBytess, 0, salt, 0, SaltSize);

            var key = new Rfc2898DeriveBytes(password, salt, Iterations);
            byte[] hash = key.GetBytes(HashSize);

            for (var i = 0; i < HashSize; i++)
            {
                if (hasBytess[i + SaltSize] != hash[i])
                    return false;
            }

            return true;
        }

        #endregion Verifying Password Is Valid 



    }
}
