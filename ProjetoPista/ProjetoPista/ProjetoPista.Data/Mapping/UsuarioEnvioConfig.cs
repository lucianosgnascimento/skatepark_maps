using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class UsuarioEnvioConfig : IEntityTypeConfiguration<Usuario_envio>
	{
		public void Configure(EntityTypeBuilder<Usuario_envio> builder)
		{
			builder.ToTable("Usuario_envio");
			builder.HasKey(t => t.id_usuario_envio);
			builder.Property(t => t.id_usuario_envio);
			builder.Property(t => t.nm_usuario_envio);
			builder.Property(t => t.ds_email);
			builder.Property(t => t.nr_telefone);



		}
	}
}
