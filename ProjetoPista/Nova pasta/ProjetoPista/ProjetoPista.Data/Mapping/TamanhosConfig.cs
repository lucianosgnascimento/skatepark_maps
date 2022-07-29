using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class TamanhosConfig : IEntityTypeConfiguration<Tamanhos>
	{
		public void Configure(EntityTypeBuilder<Tamanhos> builder)
		{
			builder.ToTable("Tamanhos");
			builder.HasKey(t => t.id_Tamanho);
			builder.Property(t => t.id_Tamanho);
			builder.Property(t => t.ds_tamanho);
			
		}
	}
}
