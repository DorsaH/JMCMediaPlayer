using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace JMCMediaPLayer
{
    class HashComputer
    {
        private RNGCryptoServiceProvider cSP = new RNGCryptoServiceProvider();
        private int SALT_SIZE = 40;
        UTF8Encoding enc8 = new UTF8Encoding();

        public HashComputer() { }

        /// <summary>
        /// Salt and hashes the given password and output the salt
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
        public string getHashedSaltedPassword(string password, string salt)
        {

            string saltedPassword = password + salt;
            string hashedSaltedPassword = hashPassword(saltedPassword);
            return hashedSaltedPassword;
        }

        /// <summary>
        /// generates a random salt
        /// </summary>
        /// <returns></returns>
        public string generateSalt()
        {
            byte[] randomBytes = new byte[SALT_SIZE];
            cSP.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        /// <summary>
        ///  will return the Hash string of the given string salted password
        /// </summary>
        /// <param name="saltedPassword"></param>
        /// <returns></returns>
        public string hashPassword(string saltedPassword)
        {
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = enc8.GetBytes(saltedPassword);
            byte[] resultBytes = sha.ComputeHash(dataBytes);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// Validating if the password matches with the pre given hashed password
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool isPasswordMatch(string password, string salt, string hashedPassword)
        {
            string finalString = password + salt;
            return hashedPassword == hashPassword(finalString);
        }
    }
}
