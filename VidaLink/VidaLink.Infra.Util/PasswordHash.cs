using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Infra.Util
{
    public class PasswordHash
    {
        public static string CreatePasswordHash(string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            var bytes = Encoding.UTF8.GetBytes(password);
            var newpassword = sha.ComputeHash(bytes);
            var hashedpassword = HexStringFromBytes(newpassword);

            var part1 = hashedpassword.Substring(0, 20);
            var part2 = hashedpassword.Substring(20, 20);

            byte[] salted = Encoding.UTF8.GetBytes($"{part1}{password}{part2}");

            SHA256 hasher = new SHA256Managed();
            byte[] hashed = hasher.ComputeHash(salted);

            return Convert.ToBase64String(hashed);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
