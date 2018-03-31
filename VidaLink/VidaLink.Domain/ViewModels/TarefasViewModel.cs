using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Enums;
using VidaLink.Domain.ViewModels.Base;

namespace VidaLink.Domain.ViewModels
{
    public class TarefasViewModel : BaseViewModel
    {
        public Guid IDUsuario { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataExecucao { get; set; }
        public StatusTarefasEnum Status { get; set; }
    }
}
