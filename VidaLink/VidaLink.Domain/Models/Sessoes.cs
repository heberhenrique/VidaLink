using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models.Base;

namespace VidaLink.Domain.Models
{
    public class Sessoes : BaseModel
    {
        public Guid IDUsuario { get; set; }
        public string Token { get; set; }
        public DateTime? DataExpiracao { get; set; }
        public virtual Usuarios Usuario { get; set; }
    }
}
