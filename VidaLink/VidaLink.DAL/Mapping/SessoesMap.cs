using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models;

namespace VidaLink.DAL.Mapping
{
    public class SessoesMap : EntityTypeConfiguration<Sessoes>
    {
        public SessoesMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties
            Property(t => t.Token).IsRequired();

            // Table & Column Mappings
            ToTable("Sessoes");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.IDUsuario).HasColumnName("IDUsuario");
            Property(t => t.DataExpiracao).HasColumnName("DataExpiracao");
            Property(t => t.Token).HasColumnName("Token");
            Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            Property(t => t.DataUltimaAlteracao).HasColumnName("DataUltimaAlteracao");
            Property(t => t.CriadoPorID).HasColumnName("CriadoPorID");
            Property(t => t.AlteradoPorID).HasColumnName("AlteradoPorID");
            Property(t => t.Excluido).HasColumnName("Excluido");

            // Relationships
            HasRequired(t => t.Usuario).WithMany().HasForeignKey(t => t.IDUsuario);
        }
    }
}
