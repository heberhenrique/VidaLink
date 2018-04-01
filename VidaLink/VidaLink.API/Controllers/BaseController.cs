using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidaLink.BLL.Interfaces;
using VidaLink.BLL.Interfaces.Base;
using VidaLink.Domain.Models.Base;
using VidaLink.Domain.ViewModels.Base;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.API.Controllers
{
    public class BaseController<TModel, TViewModel> : ApiController
        where TModel : BaseModel
        where TViewModel : BaseViewModel
    {
        public readonly IBaseLogger _logger;
        public readonly IBaseService<TModel, TViewModel> _defaultService;
        private readonly ISessoesService _sessoesService;


        public BaseController(
            IBaseLogger logger
            ,IBaseService<TModel, TViewModel> defaultService
            ,ISessoesService sessoesService
            )
        {
            _logger = logger;
            _defaultService = defaultService;
            _sessoesService = sessoesService;
        }

        public virtual BaseListResponse<TViewModel> Get()
        {
            var response = new BaseListResponse<TViewModel>();
            try
            {
                response.List = _defaultService.Read().ToList();
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try get an item", ex);
                throw ex;
            }
            return response;
        }

        public virtual BaseResponse<TViewModel> Get(Guid id)
        {
            var response = new BaseResponse<TViewModel>();
            try
            {
                response.Model = _defaultService.ReadById(id);

                if (response.Model != null)
                {
                    response.HttpStatusCode = HttpStatusCode.OK;
                    response.Message = "Dados obtidos com sucesso";
                }
            }
            catch (Exception ex)
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Error: {ex.Message}";
                _logger.Erro("Error when try get an item by id", ex);
            }
            return response;
        }

        public virtual BaseResponse<TViewModel> Post(TViewModel viewmodel)
        {
            var response = new BaseResponse<TViewModel>();
            try
            {
                if (!ModelState.IsValid || viewmodel == null)
                {
                    response.HttpStatusCode = HttpStatusCode.BadRequest;
                    response.Message = "Invalid View Model";
                    return response;
                }

                response.Model = _defaultService.Save(viewmodel);

                if (response.Model != null)
                {
                    response.HttpStatusCode = HttpStatusCode.OK;
                    response.Message = "Saved";
                }
                else
                {
                    response.HttpStatusCode = HttpStatusCode.InternalServerError;
                    response.Message = "Error when try create or update an item";
                    _logger.Erro("Error when try create or update an item", null);
                }
            }
            catch (Exception ex)
            {
                response.HttpStatusCode = HttpStatusCode.InternalServerError;
                response.Message = $"Error: { ex.Message }";
                _logger.Erro("Erro when try create or update an item", ex);
            }

            return response;
        }

        public virtual void Delete(Guid id)
        {
            try
            {
                _defaultService.Delete(id);
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try delete an item", ex);
            }
        }

        protected bool ValidateToken()
        {
            var response = false;
            IEnumerable<string> values;
            try
            {
                Request.Headers.TryGetValues("User-Token", out values);
                var token = values.FirstOrDefault();
                var sessao = _sessoesService.Read()
                                            .Where(t => t.Token == token)
                                            .FirstOrDefault();

                if (sessao.DataExpiracao.HasValue && sessao.DataExpiracao.Value > DateTime.Now.ToUniversalTime())
                {

                    response = true;
                }

                _defaultService.SetUserLoggedIn(sessao.Usuario);
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro ao validar o token: ", ex);
                throw ex;
            }

            return response;
        }

    }
}
