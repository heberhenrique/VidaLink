using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models.Base;

namespace VidaLink.Domain.Models
{
    public class Usuarios : BaseModel
    {
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string UserName { get; set; }

        public virtual ICollection<UsuariosPermissoes> Permissoes { get; set; }
        public virtual ICollection<Tarefas> Tarefas { get; set; }

    }
}
