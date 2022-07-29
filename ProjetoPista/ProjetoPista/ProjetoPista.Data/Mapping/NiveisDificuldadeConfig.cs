using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class NiveisDificuldadeConfig : IEntityTypeConfiguration<Niveis_dificuldade>
	{
		public void Configure(EntityTypeBuilder<Niveis_dificuldade> builder)
		{
			builder.ToTable("Niveis_dificuldade");
			builder.HasKey(t => t.id_nivel_dificuldade);
			builder.Property(t => t.id_nivel_dificuldade);
			builder.Property(t => t.nm_nivel_dificuldade);
			builder.Property(t => t.ds_nivel_dificuldade);

		}
	}
}
