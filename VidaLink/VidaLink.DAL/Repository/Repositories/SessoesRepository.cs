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
    public class SessoesRepository : RepositoryBase<Sessoes>, ISessoesRepository
    {
        public SessoesRepository(
            VidaLinkContext context,
            IBaseLogger logger) : base(context, logger)
        {

        }

        public Sessoes ObterSessaoAtiva(Guid userId)
        {
            var model = DbSet.AsQueryable()
                .Where(t => t.IDUsuario == userId)
                .Where(t => t.DataExpiracao.Value > DateTime.Now)
                .FirstOrDefault();

            return model;
        }
    }
}
