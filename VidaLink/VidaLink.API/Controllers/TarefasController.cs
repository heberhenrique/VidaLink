using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidaLink.BLL.Interfaces;
using VidaLink.Domain.Models;
using VidaLink.Domain.ViewModels;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.API.Controllers
{
    public class TarefasController : BaseController<Tarefas, TarefasViewModel>
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="tarefasService"></param>
        /// <param name="sessoesService"></param>
        public TarefasController(
            IBaseLogger logger,
            ITarefasService tarefasService,
            ISessoesService sessoesService) : base(logger, tarefasService, sessoesService)
        {

        }
    }
}
