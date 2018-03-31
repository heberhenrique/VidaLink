using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Mappers;
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
