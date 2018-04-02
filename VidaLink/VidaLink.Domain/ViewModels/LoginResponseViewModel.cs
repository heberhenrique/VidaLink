using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.ViewModels
{
    public class LoginResponseViewModel
    {
        public bool Valido { get; set; }
        public string Token { get; set; }
        public DateTime ValidoAte { get; set; }
    }
}
