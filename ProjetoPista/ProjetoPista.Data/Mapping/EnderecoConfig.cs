using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class EnderecoConfig : IEntityTypeConfiguration<Endereco>
	{
		public void Configure(EntityTypeBuilder<Endereco> builder)
		{
			builder.ToTable("Endereco");
			builder.HasKey(t => t.id_endereco);
			builder.Property(t => t.id_endereco);
			builder.Property(t => t.ds_endereco);
			builder.Property(t => t.nr_endereco);
			builder.Property(t => t.cd_cep);
			builder.Property(t => t.nr_latitude);
			builder.Property(t => t.nr_longitude);
			builder.Property(t => t.id_cidade);
			
		}
	}
}
