using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.BLL.Base
{
    interface ISessionInformation
    {
        Guid IDUsuario { get; }
        int NivelAcesso { get; }
        string Token { get; }
        void SetRepositoryBase(Guid usuarioID, string token, int IDNivelacesso);
    }
}
