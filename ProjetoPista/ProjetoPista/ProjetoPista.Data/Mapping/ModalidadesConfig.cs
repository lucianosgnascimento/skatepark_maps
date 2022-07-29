using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class ModalidadesConfig : IEntityTypeConfiguration<Modalidades>
	{
		public void Configure(EntityTypeBuilder<Modalidades> builder)
		{
			builder.ToTable("Modalidades");
			builder.HasKey(t => t.id_modalidade);
			builder.Property(t => t.id_modalidade);
			builder.Property(t => t.nm_modalidade);
			builder.Property(t => t.ds_modalidade);
			
		}
	}
}
