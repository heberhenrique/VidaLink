using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models;

namespace VidaLink.DAL.Mapping
{
    public class UsuariosMap : EntityTypeConfiguration<Usuarios>
    {
        public UsuariosMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties

            // Table & Column Mappings
            ToTable("Usuarios");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.Email).HasColumnName("Email");
            Property(t => t.EmailConfirmed).HasColumnName("EmailConfirmed");
            Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            Property(t => t.UserName).HasColumnName("UserName");

            Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            Property(t => t.DataUltimaAlteracao).HasColumnName("DataUltimaAlteracao");
            Property(t => t.CriadoPorID).HasColumnName("CriadoPorID");
            Property(t => t.AlteradoPorID).HasColumnName("AlteradoPorID");
            Property(t => t.Excluido).HasColumnName("Excluido");

            // Relationships
        }
    }
}
