using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Enums;
using VidaLink.Domain.Models.Base;

namespace VidaLink.Domain.Models
{
    public class UsuariosPermissoes : BaseModel
    {
        public Guid IDUsuario { get; set; }
        public TipoUsuarioEnum Nivel { get; set; }

        public virtual Usuarios Usuarios { get; set; }
    }
}
