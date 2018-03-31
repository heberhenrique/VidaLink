using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Infra.Util
{
    public class TokenGenerator
    {
        private static Random random = new Random();
        public static string GerarToken()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789=-@$&*#+";
            return new string(Enumerable.Repeat(chars, 128)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
