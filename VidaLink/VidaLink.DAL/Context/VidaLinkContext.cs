using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.DAL.Mapping;
using VidaLink.Domain.Models;
using VidaLink.Domain.Models.Base;

namespace VidaLink.DAL.Context
{
    public class VidaLinkContext : DbContext
    {
        private static VidaLinkContext _instance = new VidaLinkContext();
        protected Guid UsuarioID { get; private set; }
        public static VidaLinkContext Instance { get { return _instance; } }

        #region DbSets

        public DbSet<Tarefas> Tarefas { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }

        #endregion


        #region Construtores

        static VidaLinkContext()
        {
            Database.SetInitializer<VidaLinkContext>(null);
        }

        public VidaLinkContext()
            : base("DevConnection")
        {
        }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new TarefasMap());
            modelBuilder.Configurations.Add(new UsuariosMap());
            base.OnModelCreating(modelBuilder);
        }

        public void setUsuarioIDContext(Guid usuarioID_)
        {
            UsuarioID = usuarioID_;
        }

        public override int SaveChanges()
        {
            int response = -1;
            try
            {
                var entities = ChangeTracker
                .Entries()
                .Where(x => x.Entity is BaseModel && (x.State == EntityState.Added || x.State == EntityState.Modified || x.State == EntityState.Deleted));

                if ((UsuarioID == null || UsuarioID == Guid.Empty) &&
                    entities.Any(e => ((BaseModel)e.Entity).CriadoPorID != null &&
                    ((BaseModel)e.Entity).AlteradoPorID == null))
                {
                    var _baseEntity = (BaseModel)(entities.FirstOrDefault(e => ((BaseModel)e.Entity).CriadoPorID != null &&
                                                                               ((BaseModel)e.Entity).AlteradoPorID == null).Entity);
                    UsuarioID = _baseEntity.CriadoPorID;
                }

                foreach (var entity in entities)
                {

                    if (entity.State == EntityState.Added)
                    {
                        ((BaseModel)entity.Entity).DataCriacao = DateTime.Now.ToUniversalTime();
                        if (((BaseModel)entity.Entity).CriadoPorID == Guid.Empty)
                        {
                            ((BaseModel)entity.Entity).CriadoPorID = UsuarioID;
                        }
                        ((BaseModel)entity.Entity).Excluido = false;
                    }

                    if (entity.State == EntityState.Modified)
                    {
                        ((BaseModel)entity.Entity).DataUltimaAlteracao = DateTime.Now.ToUniversalTime();
                        ((BaseModel)entity.Entity).AlteradoPorID = UsuarioID;
                    }

                    if (entity.State == EntityState.Deleted)
                    {
                        entity.State = EntityState.Modified;
                        ((BaseModel)entity.Entity).Excluido = true;
                    }



                    //foreach (string protertyName in entity.g)
                    //{
                    //    entity.CurrentValues() != entity.CurrentValues()
                    //}

                }

                response = base.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                throw ex;
            }

            return response;
        }
    }
}
