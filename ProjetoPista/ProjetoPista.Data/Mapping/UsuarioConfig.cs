using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class UsuarioConfig : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.ToTable("Usuario");
			builder.HasKey(t => t.IdUsuario);
			builder.Property(t => t.IdUsuario);
			builder.Property(t => t.Nome);
			builder.Property(t => t.Email);
			builder.HasIndex(t => t.Login).IsUnique();
			builder.Property(t => t.Hash);
			builder.Property(t => t.Salt);
		}
	}
}
