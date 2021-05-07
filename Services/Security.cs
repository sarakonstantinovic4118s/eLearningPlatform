using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Services
{
    public static class Security
    {
        public static string Hash256(string password)
        {

            SHA256 hash = SHA256.Create();
            password = "learning" + password;
            byte[] bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            // niz bajtova u string
            StringBuilder builder = new StringBuilder();
            foreach (var b in bytes)
                builder.Append(b.ToString("x2"));
            return builder.ToString();
        }
    }
}
