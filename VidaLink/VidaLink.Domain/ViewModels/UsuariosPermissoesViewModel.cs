using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Enums;
using VidaLink.Domain.ViewModels.Base;

namespace VidaLink.Domain.ViewModels
{
    public class UsuariosPermissoesViewModel : BaseViewModel
    {
        public Guid IDUsuario { get; set; }
        public TipoUsuarioEnum Nivel { get; set; }
    }
}
