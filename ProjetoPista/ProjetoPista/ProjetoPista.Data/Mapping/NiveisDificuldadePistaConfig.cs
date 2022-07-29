using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class NiveisDificuldadePistaConfig : IEntityTypeConfiguration<Niveis_dificuldade_Pistas>
	{
		public void Configure(EntityTypeBuilder<Niveis_dificuldade_Pistas> builder)
		{
			builder.ToTable("Niveis_dificuldade_Pistas");
			builder.HasKey(t => t.id_nivel_dificuldade_pista);
			builder.Property(t => t.id_nivel_dificuldade_pista);
			builder.Property(t => t.id_nivel_dificuldade);
			builder.Property(t => t.id_pista);
			
		}
	}
}
