using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.DAL.Context;
using VidaLink.DAL.Repository.Architecture;
using VidaLink.DAL.Repository.Interfaces;
using VidaLink.DAL.Repository.Interfaces.Base;
using VidaLink.DAL.Repository.Repositories;
using VidaLink.DAL.Repository.Repositories.Base;
using VidaLink.Domain.Mappers;
using VidaLink.Domain.Models.Base;
using VidaLink.Infra.Log.Interfaces;
using VidaLink.Infra.Log.Services;

namespace VidaLink.Infra.Ioc
{
    public class BootStrapper
    {
        public static Container Container { get; set; }

        public static void Register(Container container)
        {
            Container = container;

            #region DAL

            #region  Architecture 

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<VidaLinkContext>(Lifestyle.Scoped);

            #endregion

            container.Register<IRepositoryBase<BaseModel>, RepositoryBase<BaseModel>>(Lifestyle.Scoped);

            container.Register<IUsuariosRepository, UsuariosRepository>(Lifestyle.Scoped);

            #endregion

            #region BLL

            #endregion

            #region Domain

            container.Register<IMapperConfig, MapperConfig>(Lifestyle.Singleton);

            #endregion

            #region Infra

            container.Register<IBaseLogger, BaseLogger>(Lifestyle.Singleton);

            #endregion
        }
    }
}
