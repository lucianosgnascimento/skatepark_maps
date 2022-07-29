using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class EstadoConfig : IEntityTypeConfiguration<Estado>
	{
		public void Configure(EntityTypeBuilder<Estado> builder)
		{
			builder.ToTable("Estado");
			builder.HasKey(t => t.id_estado);
			builder.Property(t => t.id_estado);
			builder.Property(t => t.nm_estado);
			
		}
	}
}
