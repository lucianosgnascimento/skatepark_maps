using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class PistaProfessorConfig : IEntityTypeConfiguration<Pistas_Professores>
	{
		public void Configure(EntityTypeBuilder<Pistas_Professores> builder)
		{
			builder.ToTable("Pistas_Professores");
			builder.HasKey(t => t.id_pista_professor);
			builder.Property(t => t.id_pista_professor);
			builder.Property(t => t.id_pista);
			builder.Property(t => t.id_professor);
			
		}
	}
}
