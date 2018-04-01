using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.ViewModels.Base;

namespace VidaLink.Domain.ViewModels
{
    public class SessoesViewModel : BaseViewModel
    {
        public Guid IDUsuario { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public virtual UsuariosViewModel Usuario { get; set; }
    }
}
