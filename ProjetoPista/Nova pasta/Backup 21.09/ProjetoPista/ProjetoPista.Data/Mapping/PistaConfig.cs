using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class PistaConfig : IEntityTypeConfiguration<Pistas>
	{
		public void Configure(EntityTypeBuilder<Pistas> builder)
		{
			builder.ToTable("Pistas");
			builder.HasKey(t => t.ID_pista);
			builder.Property(t => t.ID_pista);
			builder.Property(t => t.nm_pista);
			builder.Property(t => t.ds_pista);
			builder.Property(t => t.fl_paga);
			builder.Property(t => t.ds_horario_funcionamento);
			builder.Property(t => t.fl_pista_ativa);
			builder.Property(t => t.fl_capacete);
			builder.Property(t => t.fl_aluga_capacete);
			builder.Property(t => t.id_status_aprovacao);
			builder.Property(t => t.nr_nota);
			builder.Property(t => t.id_tamanho);
			builder.Property(t => t.ds_notas_gerais);
			builder.Property(t => t.id_endereco);
		}
	}
}
