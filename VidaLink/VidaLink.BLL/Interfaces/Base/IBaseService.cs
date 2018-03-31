using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models.Base;
using VidaLink.Domain.ViewModels;
using VidaLink.Domain.ViewModels.Base;

namespace VidaLink.BLL.Interfaces.Base
{
    public interface IBaseService<TModel, TViewModel>
        where TModel : BaseModel
        where TViewModel : BaseViewModel
    {
        /// <summary>
        /// Create / Update
        /// </summary>
        /// <param name="request">model to save</param>
        /// <returns>Model with Id</returns>
        TViewModel Save(TViewModel request);

        /// <summary>
        /// Returns all
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<TViewModel> Read();

        /// <summary>
        /// Returns a Queryable according with request parameters
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        IQueryable<TViewModel> Read(TViewModel request);

        /// <summary>
        /// Returns a single object that match id parameter
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TViewModel ReadById(Guid id);

        /// <summary>
        /// Delete a row
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool Delete(Guid Id);

        /// <summary>
        /// Commit that operation
        /// </summary>
        /// <returns></returns>
        bool Commit();

        void SetUserLoggedIn(Guid id);
        void SetUserLoggedIn(UsuariosViewModel usuario);
    }
}
