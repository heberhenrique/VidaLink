using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.Infra.Log.Services
{
    public class BaseLogger : IBaseLogger
    {
        public static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public BaseLogger()
        {
            if (!LogManager.GetCurrentLoggers().Any())
            {
                XmlConfigurator.Configure();
            }
            else
            {
                string LogFile = ConfigurationManager.AppSettings["Log4NetFile"];

                if (LogFile != null)
                {
                    if (!File.Exists(LogFile))
                    {
                        XmlConfigurator.Configure();
                    }
                }
            }
        }

        public void Erro(string title, Exception exception)
        {
            if (exception != null)
            {
                Logger.Error(title, exception);
            }
            else
            {
                Logger.Error(title);
            }

        }
        public void Informacao(string Title, string Text)
        {
            Logger.Info($"{Title}: {Text}");

        }
        public void Atencao(string Title, string Text)
        {
            Logger.Warn($"{Title}: {Text}");
        }
        public void Critico(object ErroCritico)
        {
            Logger.Fatal(ErroCritico);
        }
        public void Dispose()
        {
            Dispose(true);
        }
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                //Drop Objects
            }
        }
    }
}
