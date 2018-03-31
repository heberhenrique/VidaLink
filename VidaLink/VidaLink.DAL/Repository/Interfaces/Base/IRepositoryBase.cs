using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models.Base;

namespace VidaLink.DAL.Repository.Interfaces.Base
{
    public interface IRepositoryBase<TModel> where TModel : BaseModel
    {
        TModel Create(TModel obj);
        TModel ReadById(int id);
        TModel ReadById(Guid id);
        TModel ReadById(string id);
        IEnumerable<TModel> Read(bool? WithExcludedItens = false);
        IEnumerable<TModel> ReadAll(bool? WithExcludedItens = false);
        void Update(TModel obj);
        void Delete(TModel obj);
        bool DeleteById(int id);
        bool DeleteById(Guid id);
        bool DeleteById(string id);
        void Dispose();

        void SetUserLoggedIn(Guid id);
    }
}
