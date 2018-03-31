using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VidaLink.Domain.Models;

namespace VidaLink.DAL.Mapping
{
    public class TarefasMap : EntityTypeConfiguration<Tarefas>
    {
        public TarefasMap()
        {
            // Primary Key
            HasKey(t => t.ID);

            // Properties

            // Table & Column Mappings
            ToTable("Tarefas");
            Property(t => t.ID).HasColumnName("ID");
            Property(t => t.IDUsuario).HasColumnName("IDUsuario");
            Property(t => t.DataExecucao).HasColumnName("DataExecucao");
            Property(t => t.Descricao).HasColumnName("Descricao");
            Property(t => t.Titulo).HasColumnName("Titulo");
            Property(t => t.Status).HasColumnName("Status");

            Property(t => t.DataCriacao).HasColumnName("DataCriacao");
            Property(t => t.DataUltimaAlteracao).HasColumnName("DataUltimaAlteracao");
            Property(t => t.CriadoPorID).HasColumnName("CriadoPorID");
            Property(t => t.AlteradoPorID).HasColumnName("AlteradoPorID");
            Property(t => t.Excluido).HasColumnName("Excluido");

            // Relationships
            HasRequired(t => t.Usuario).WithMany(t => t.Tarefas).HasForeignKey(t => t.IDUsuario);
        }
    }
}
