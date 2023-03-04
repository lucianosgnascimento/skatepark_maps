using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class CidadeConfig : IEntityTypeConfiguration<Cidade>
	{
		public void Configure(EntityTypeBuilder<Cidade> builder)
		{
			builder.ToTable("Cidade");
			builder.HasKey(t => t.id_cidade);
			builder.Property(t => t.id_cidade);
			builder.Property(t => t.nm_cidade);
			builder.Property(t => t.id_estado);
			
		}
	}
}
