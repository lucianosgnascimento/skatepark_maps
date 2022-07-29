using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetoPista.Model.Entities
{
	public class Usuario_envio
	{
		public virtual int id_usuario_envio { get; set; }
		public virtual string nm_usuario_envio { get; set; }
		public virtual string nr_telefone { get; set; }
		public virtual string ds_email { get; set; }

	}
}
