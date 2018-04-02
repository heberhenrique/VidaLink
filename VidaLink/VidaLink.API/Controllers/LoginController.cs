using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidaLink.BLL.Interfaces;
using VidaLink.Domain.ViewModels;
using VidaLink.Domain.ViewModels.Base;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.API.Controllers
{
    public class LoginController : ApiController
    {
        private readonly IBaseLogger _logger;
        private readonly ILoginService _loginService;
        public LoginController(
            IBaseLogger logger,
            ILoginService loginService)
        {
            _logger = logger;
            _loginService = loginService;
        }

        public BaseResponse<LoginResponseViewModel> Post(LoginRequestViewModel request)
        {
            var response = new BaseResponse<LoginResponseViewModel>();

            try
            {
                if (ModelState.IsValid)
                {
                    response.Model = _loginService.EfetuarLogin(request.Email, request.Password);
                    response.HttpStatusCode = HttpStatusCode.OK;
                    response.Message = "Login efetuado com sucesso";
                }
                else
                {
                    response.HttpStatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid View Model";
                    return response;
                }

            }
            catch (Exception ex)
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Erro ao efetuar o login: {ex.Message}";

            }

            return response;
        }
    }
}
