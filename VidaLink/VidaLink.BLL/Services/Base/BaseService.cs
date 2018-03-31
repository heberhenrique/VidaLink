using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.BLL.Interfaces.Base;
using VidaLink.DAL.Repository.Architecture;
using VidaLink.DAL.Repository.Interfaces.Base;
using VidaLink.Domain.Mappers;
using VidaLink.Domain.Models.Base;
using VidaLink.Domain.Util;
using VidaLink.Domain.ViewModels;
using VidaLink.Domain.ViewModels.Base;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.BLL.Services.Base
{
    public class BaseService<TModel, TViewModel> : IBaseService<TModel, TViewModel>
        where TModel : BaseModel
        where TViewModel : BaseViewModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public readonly IBaseLogger _logger;
        public readonly IMapperConfig _mapInstace;
        public readonly IRepositoryBase<TModel> _defaultRepository;

        public UsuariosViewModel UsuarioLogado { get; private set; }

        public BaseService(
            IBaseLogger logger,
            IUnitOfWork unitOfWork,
            IMapperConfig mapInstace,
            IRepositoryBase<TModel> defaultRepository)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _mapInstace = mapInstace;
            _defaultRepository = defaultRepository;
        }
        public virtual bool Delete(Guid Id)
        {
            try
            {
                var model = _defaultRepository.ReadById(Id);
                _defaultRepository.Delete(model);
                Commit();
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try delete an item", ex);
                return false;
            }

            return true;
        }

        public virtual IQueryable<TViewModel> Read()
        {
            var response = default(IEnumerable<TViewModel>);
            try
            {
                var result = _defaultRepository.ReadAll();
                response = _mapInstace.Mapper.Map<IEnumerable<TViewModel>>(result.ToList());
            }
            catch (Exception ex)
            {
                _logger.Erro("Error when try to read", ex);
                throw ex;
            }
            return response.AsQueryable();
        }

        public virtual IQueryable<TViewModel> Read(TViewModel request)
        {
            throw new NotImplementedException();
        }

        public virtual TViewModel ReadById(Guid id)
        {
            var response = default(TViewModel);
            try
            {
                var result = _defaultRepository.ReadById(id);
                response = _mapInstace.Mapper.Map<TViewModel>(result);
            }
            catch (Exception ex)
            {
                _logger.Erro("Error when try to read", ex);
                throw ex;
            }
            return response;
        }

        public virtual TViewModel Save(TViewModel viewmodel)
        {
            var response = default(TViewModel);
            try
            {
                var model = _mapInstace.Mapper.Map<TModel>(viewmodel);

                if (model.ID == Guid.Empty)
                {
                    model = model.GenerateIDs();
                    _defaultRepository.Create(model);
                }
                else
                {
                    _defaultRepository.Update(model);
                }

                if (Commit())
                {
                    if (model.ID == Guid.Empty)
                    {
                        throw new Exception("Erro ao salvar, favor verificar");
                    }
                    response = _mapInstace.Mapper.Map<TViewModel>(model);
                }
                else
                {
                    response = viewmodel;
                }

            }
            catch (Exception ex)
            {
                _logger.Erro("Error when try create an item", ex);
                throw ex;
            }

            return response;
        }

        public virtual bool Commit()
        {
            try
            {
                _unitOfWork.Commit();
                return true;
            }
            catch (Exception ex)
            {
                string stackTrace2 = string.Empty;
                string stackTrace3 = string.Empty;

                string mensagem2 = string.Empty;
                string mensagem3 = string.Empty;

                if (ex.InnerException != null)
                {
                    stackTrace2 = ex.InnerException.StackTrace;
                    mensagem2 = ex.InnerException.Message;

                    if (ex.InnerException.InnerException != null)
                    {
                        stackTrace3 = ex.InnerException.InnerException.StackTrace;
                        mensagem3 = ex.InnerException.InnerException.Message;
                    }
                }
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Error when try to Commit.");
                sb.AppendLine($"Message 1 { ex.Message }");
                sb.AppendLine($"Stack Trace 1: { ex.StackTrace }");
                sb.AppendLine($"Message 2 { mensagem2 }");
                sb.AppendLine($"Stack Trace 2: { stackTrace2 }");
                sb.AppendLine($"Message 3 { mensagem3 }");
                sb.AppendLine($"Stack Trace 3: { stackTrace3 }");
                _logger.Erro(sb.ToString(), ex);
                return false;
            }
        }

        public void SetUserLoggedIn(Guid id)
        {
            _defaultRepository.SetUserLoggedIn(id);
        }

        public void SetUserLoggedIn(UsuariosViewModel usuario)
        {
            UsuarioLogado = usuario;
            SetUserLoggedIn(usuario.ID);
        }
    }
}
