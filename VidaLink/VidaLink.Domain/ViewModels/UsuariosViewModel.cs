using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.ViewModels.Base;

namespace VidaLink.Domain.ViewModels
{
    public class UsuariosViewModel : BaseViewModel
    {
        [Required(ErrorMessage = "Por favor informe o e-mail", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor informe um endereço de e-mail válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserName { get { return Email; } }

        [Required]
        [StringLength(100, ErrorMessage = "A senha deve ter ao menos 6 caracteres de extensão.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Senha")]
        [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não conferem")]
        public string ConfirmPassword { get; set; }
        public string PasswordHash { get; set; }

        public virtual ICollection<UsuariosPermissoesViewModel> Permissoes { get; set; }

        public UsuariosViewModel()
        {
            Permissoes = new List<UsuariosPermissoesViewModel>();
        }
    }
}
