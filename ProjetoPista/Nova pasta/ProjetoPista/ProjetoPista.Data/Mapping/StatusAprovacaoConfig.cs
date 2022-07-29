using System;
using ProjetoPista.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ProjetoPista.Data.Mapping
{
	public class StatusAprovacaoConfig : IEntityTypeConfiguration<Status_aprovacao>
	{
		public void Configure(EntityTypeBuilder<Status_aprovacao> builder)
		{
			builder.ToTable("Status_aprovacao");
			builder.HasKey(t => t.id_status_aprovacao);
			builder.Property(t => t.id_status_aprovacao);
			builder.Property(t => t.ds_status_aprovacao);

		}
	}
}
