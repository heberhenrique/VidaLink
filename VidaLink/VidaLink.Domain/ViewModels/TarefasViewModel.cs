using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe o título da tarefa")]
        [MaxLength(100,ErrorMessage = "O Campo título pode conter no máximo 100 caracteres")]
        public string Titulo { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Por favor informe a descrição da tarefa")]
        public string Descricao { get; set; }
        public DateTime? DataExecucao { get; set; }
        public StatusTarefasEnum Status { get; set; }
    }
}
