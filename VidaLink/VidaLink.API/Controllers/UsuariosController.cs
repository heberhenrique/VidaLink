using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidaLink.BLL.Interfaces;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;
using VidaLink.Domain.ViewModels.Base;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.API.Controllers
{
    /// <summary>
    /// UsuariosController
    /// </summary>
    public class UsuariosController : BaseController<Usuarios, UsuariosViewModel>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="usuariosService"></param>
        /// <param name="sessoesService"></param>
        public UsuariosController(
            IBaseLogger logger,
            IUsuariosService usuariosService,
            ISessoesService sessoesService) : base(logger, usuariosService, sessoesService)
        {

        }

        public override BaseResponse<UsuariosViewModel> Post(UsuariosViewModel viewmodel)
        {
            if (base.ValidateToken())
            {
                return base.Post(viewmodel);
            }
            else
            {
                var response = new BaseResponse<UsuariosViewModel>();
                response.HttpStatusCode = HttpStatusCode.Unauthorized;
                response.Message = "Token inválido! Favor logar novamente";
                return response;
            }
        }
    }
}
