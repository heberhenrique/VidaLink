using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VidaLink.Domain.ViewModels
{
    public class LoginRequestViewModel
    {
        [Required(ErrorMessage = "Por favor informe o e-mail", AllowEmptyStrings = false)]
        [DataType(DataType.EmailAddress, ErrorMessage = "Por favor informe um endereço de e-mail válido")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor informe a senha", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}
