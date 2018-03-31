using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Enums;
using VidaLink.Domain.Models.Base;

namespace VidaLink.Domain.Models
{
    public class Tarefas : BaseModel
    {
        public Guid IDUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataExecucao { get; set; }
        public StatusTarefasEnum Status { get; set; }

        public virtual Usuarios Usuario { get; set; }
    }
}
