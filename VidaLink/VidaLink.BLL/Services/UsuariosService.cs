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
using VidaLink.Infra.Util;

namespace VidaLink.BLL.Services
{
    public class UsuariosService : BaseService<Usuarios, UsuariosViewModel>, IUsuariosService
    {
        public UsuariosService(
            IBaseLogger logger,
            IUnitOfWork unitOfWork,
            IMapperConfig mapInstace,
            IUsuariosRepository usuarioRepository) : base(logger, unitOfWork, mapInstace, usuarioRepository)
        {

        }

        public override UsuariosViewModel Save(UsuariosViewModel viewmodel)
        {
            var response = default(UsuariosViewModel);
            if (!string.IsNullOrWhiteSpace(viewmodel?.Password) &&
                !string.IsNullOrWhiteSpace(viewmodel?.ConfirmPassword) &&
                viewmodel.Password.Equals(viewmodel.ConfirmPassword))
            {
                viewmodel.PasswordHash = PasswordHash.CreatePasswordHash(viewmodel.Password);
            }

            //if (viewmodel.Permissoes != null && viewmodel.Permissoes.Count > 0)
            //{
            //    foreach (var permissao in viewmodel.Permissoes)
            //    {
            //        if (ValidarPermissaoUsuarioLogado(permissao))
            //        {
            //            viewmodel.Permissoes.FirstOrDefault().ID = Guid.NewGuid();
            //        }
            //        else
            //        {
            //            throw new Exception("Usuário sem permissão para cadastrar esse tipo de usuário");
            //        }
            //    }

            //}

            response = base.Save(viewmodel);

            return response;
        }

        //public bool ValidarPermissaoUsuarioLogado(UsuariosPermissoesViewModel permissao)
        //{
        //    if ((int)UsuarioLogado.Permissoes.FirstOrDefault().Nivel < (int)permissao.Nivel)
        //    {
        //        return false;
        //    }

        //    return true;
        //}
    }
}
