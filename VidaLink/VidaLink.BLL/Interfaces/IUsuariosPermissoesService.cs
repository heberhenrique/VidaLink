using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.BLL.Interfaces.Base;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;

namespace VidaLink.BLL.Interfaces
{
    public interface IUsuariosPermissoesService : IBaseService<UsuariosPermissoes, UsuariosPermissoesViewModel>
    {
    }
}
