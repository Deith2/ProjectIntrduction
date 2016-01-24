using Hobby.DTO;
using Hobby.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hobby.Utilities
{
    public static class HashPassowrd
    {
        public static string getSHA1(this User user)
        {
            var hashAlgorithm = HashAlgorithm.Create("SHA1");
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(user.Password);
            var hash = hashAlgorithm.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string getSHA1(this UserDTO user)
        {
            var hashAlgorithm = HashAlgorithm.Create("SHA1");
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(user.Password);
            var hash = hashAlgorithm.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
