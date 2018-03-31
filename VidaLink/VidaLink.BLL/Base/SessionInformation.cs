using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.DAL.Repository.Architecture;

namespace VidaLink.BLL.Base
{
    public class SessionInformation : ISessionInformation
    {
        public readonly IUnitOfWork _unitOfWork;
        public SessionInformation(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public string Token { get; private set; }
        public Guid IDUsuario { get; private set; }
        public int NivelAcesso { get; private set; }

        public void SetRepositoryBase(Guid usuarioID, string token, int nivelAcesso)
        {
            NivelAcesso = nivelAcesso;
            Token = token;

            if (usuarioID != null && usuarioID != Guid.Empty)
            {
                SetUsuarioID(usuarioID);
            }
        }
        public void SetUsuarioID(Guid usuarioID_)
        {
            if (usuarioID_ != null)
            {
                IDUsuario = usuarioID_;
                _unitOfWork.setUsuarioIDContext(usuarioID_);
            }
        }

    }
}
