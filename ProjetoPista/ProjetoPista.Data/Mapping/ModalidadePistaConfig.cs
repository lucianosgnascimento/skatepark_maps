using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class ModalidadePistaConfig : IEntityTypeConfiguration<Modalidades_Pistas>
	{
		public void Configure(EntityTypeBuilder<Modalidades_Pistas> builder)
		{
			builder.ToTable("Modalidades_Pistas");
			builder.HasKey(t => t.id_modalidade_pista);
			builder.Property(t => t.id_modalidade_pista);
			builder.Property(t => t.id_modalidade);
			builder.Property(t => t.id_pista);
			
		}
	}
}
