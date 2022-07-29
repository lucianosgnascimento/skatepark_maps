using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class FotosConfig : IEntityTypeConfiguration<Fotos>
	{
		public void Configure(EntityTypeBuilder<Fotos> builder)
		{
			builder.ToTable("Fotos");
			builder.HasKey(t => t.id_foto);
			
		}
	}
}
