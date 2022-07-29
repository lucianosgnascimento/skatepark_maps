using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class ProfessoresConfig : IEntityTypeConfiguration<Professores>
	{
		public void Configure(EntityTypeBuilder<Professores> builder)
		{
			builder.ToTable("Professores");
			builder.HasKey(t => t.id_professor);
			builder.Property(t => t.id_professor);
			builder.Property(t => t.nm_professor);
			builder.Property(t => t.cd_cpf);
			builder.Property(t => t.ds_telefone);
			builder.Property(t => t.ds_email);
			builder.Property(t => t.ds_instagram);
			builder.Property(t => t.nr_estrelas);
			builder.Property(t => t.nr_anos_experiencia);
			builder.Property(t => t.nm_apelido);
			builder.Property(t => t.vl_hora_aula);
		}
	}
}
