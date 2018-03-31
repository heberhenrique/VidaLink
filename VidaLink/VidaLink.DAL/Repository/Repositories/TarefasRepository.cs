using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.DAL.Context;
using VidaLink.DAL.Repository.Interfaces;
using VidaLink.DAL.Repository.Repositories.Base;
using VidaLink.Domain.Models;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.DAL.Repository.Repositories
{
    public class TarefasRepository : RepositoryBase<Tarefas>, ITarefasRepository
    {
        public TarefasRepository(
            VidaLinkContext context,
            IBaseLogger logger) : base(context, logger)
        {

        }
    }
}
