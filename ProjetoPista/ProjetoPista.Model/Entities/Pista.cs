using System;


namespace ProjetoPista.Model.Entities
{
	public class Pistas
	{
		public virtual int ID_pista { get; set; }
		public virtual string nm_pista { get; set; }
		public virtual string ds_pista { get; set; }
		public virtual int fl_paga { get; set; }
		public virtual string ds_horario_funcionamento { get; set; }
		public virtual int fl_pista_ativa { get; set; }
		public virtual int fl_capacete { get; set; }
		public virtual int fl_aluga_capacete { get; set; }
		public virtual int id_status_aprovacao { get; set; }
		public virtual int nr_nota { get; set; }
		public virtual int id_tamanho { get; set; }
		public virtual string ds_notas_gerais { get; set; }
		public virtual int id_endereco { get; set; }
		public virtual int id_usuario_envio { get; set; }
		public virtual int fl_cobertura { get; set; }

	}


}
