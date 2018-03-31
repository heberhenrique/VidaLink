using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.DAL.Context;
using VidaLink.DAL.Repository.Interfaces.Base;
using VidaLink.Domain.Models.Base;
using VidaLink.Infra.Log.Interfaces;

namespace VidaLink.DAL.Repository.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : BaseModel
    {
        protected readonly VidaLinkContext _context;
        protected readonly DbSet<TEntity> DbSet;
        public readonly IBaseLogger _logger;
        public RepositoryBase(
            VidaLinkContext context,
            IBaseLogger logger)
        {
            _context = context;
            DbSet = _context.Set<TEntity>();
            _logger = logger;
        }
        public TEntity Create(TEntity obj)
        {
            if (obj != null)
            {
                //obj = obj.ToUniversalDateTime();
            }

            DbSet.Add(obj);

            return obj;
        }

        public void Delete(TEntity obj)
        {
            if (obj != null)
            {
                //obj = obj.ToUniversalDateTime();
            }

            obj.Excluido = true;
            _context.Entry(obj).State = EntityState.Modified;
            _context.Entry(obj).Property(x => x.CriadoPorID).IsModified = false;
            _context.Entry(obj).Property(x => x.DataCriacao).IsModified = false;
        }

        public bool DeleteById(Guid id)
        {
            try
            {
                var obj = ReadById(id);

                obj.Excluido = true;
                _context.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try delete an item", ex);
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                var obj = ReadById(id);

                obj.Excluido = true;
                _context.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try delete an item", ex);
                return false;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public IEnumerable<TEntity> Read(bool? WithExcludedItens = false)
        {
            if (!Convert.ToBoolean(WithExcludedItens))
            {
                return DbSet.Where(e => e.Excluido == WithExcludedItens).AsQueryable();
            }
            else
            {
                return DbSet.AsQueryable();
            }
        }

        public IEnumerable<TEntity> ReadAll(bool? WithExcludedItens = false)
        {
            if (!Convert.ToBoolean(WithExcludedItens))
            {
                return DbSet.Where(e => e.Excluido == WithExcludedItens).AsQueryable();
            }
            else
            {
                return DbSet.AsQueryable();
            }
        }

        public TEntity ReadById(Guid id)
        {
            var model = DbSet.AsQueryable().Where(t => t.ID == id).FirstOrDefault();

            return model;
        }

        public TEntity ReadById(int id)
        {
            var model = DbSet.Find(id);

            return model;
        }

        public void Update(TEntity obj)
        {
            if (_context.Entry(obj).Property(x => x.Excluido).CurrentValue != true)
            {
                _context.Entry(obj).State = EntityState.Modified;
            }

            _context.Entry(obj).Property(x => x.CriadoPorID).IsModified = false;
            _context.Entry(obj).Property(x => x.DataCriacao).IsModified = false;
            _context.Entry(obj).Property(x => x.Excluido).IsModified = false;
        }

        public TEntity ReadById(string id)
        {
            var model = DbSet.Find(id);

            return model;
        }

        public bool DeleteById(string id)
        {
            try
            {
                var obj = ReadById(id);

                obj.Excluido = true;
                _context.Entry(obj).State = EntityState.Modified;
                return true;
            }
            catch (Exception ex)
            {
                _logger.Erro("Erro when try delete an item", ex);
                return false;
            }
        }

        public void SetUserLoggedIn(Guid id)
        {
            _context.setUsuarioIDContext(id);
        }
    }
}
