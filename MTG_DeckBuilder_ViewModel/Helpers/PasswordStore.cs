using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MTG_DeckBuilder_ViewModel.Helpers
{
    public struct PasswordStore
    {
        public PasswordStore(byte[] salt, byte[] hash)
        {
            Salt = salt;
            Hash = hash;
        }

        public byte[] Salt;
        public byte[] Hash;

    }
    public class PasswordGenerator
    {
        public const int SALT_SIZE = 32; // size in bytes
        public const int HASH_SIZE = 256; // size in bytes
        public const int ITERATIONS = 1000; // number of pbkdf2 iterations

        public static byte[] GenerateRandomSalt()
        {
            // Generate a salt
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_SIZE];
            provider.GetBytes(salt);
            return salt;
        }

        public static PasswordStore CreateHash(string input, byte[] salt)
        {
            PasswordStore passwordStore = new PasswordStore();

            // Generate the hash
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS);
            passwordStore.Hash = pbkdf2.GetBytes(HASH_SIZE);
            passwordStore.Salt = salt;
            return passwordStore;
        }
    }
}
