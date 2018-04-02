using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models;

namespace VidaLink.DAL.Mapping
{
    public class UsuariosPermissoesMap : EntityTypeConfiguration<UsuariosPermissoes>
    {
        public UsuariosPermissoesMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties;

            // Table & Column Mappings
            ToTable("UsuariosPermissoes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.IDUsuario).HasColumnName("IDUsuario");
            Property(t => t.Nivel).HasColumnName("Nivel"); ;

            Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            Property(t => t.DataUltimaAlteracao).HasColumnName("DataUltimaAlteracao");
            Property(t => t.CriadoPorID).HasColumnName("CriadoPorID");
            Property(t => t.AlteradoPorID).HasColumnName("AlteradoPorID");
            Property(t => t.Excluido).HasColumnName("Excluido");

            // Relationships
            HasRequired(t => t.Usuarios).WithMany(t => t.Permissoes).HasForeignKey(t => t.IDUsuario);
        }
    }
}
