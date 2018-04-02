using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.ViewModels;

namespace VidaLink.BLL.Interfaces
{
    public interface ILoginService
    {
        LoginResponseViewModel EfetuarLogin(string login, string senha);
    }
}
