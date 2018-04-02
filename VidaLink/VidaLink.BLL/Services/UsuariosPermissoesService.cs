using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.BLL.Interfaces;
using VidaLink.BLL.Services.Base;
using VidaLink.DAL.Repository.Architecture;
using VidaLink.DAL.Repository.Interfaces;
using VidaLink.Domain.Mappers;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.BLL.Services
{
    public class UsuariosPermissoesService : BaseService<UsuariosPermissoes, UsuariosPermissoesViewModel>, IUsuariosPermissoesService
    {
        public UsuariosPermissoesService(
            IBaseLogger logger,
            IUnitOfWork unitOfWork,
            IMapperConfig mapInstace,
            IUsuariosPermissoesRepository usuariosPermissoesRepository) : base(logger, unitOfWork, mapInstace, usuariosPermissoesRepository)
        {

        }
    }
}
