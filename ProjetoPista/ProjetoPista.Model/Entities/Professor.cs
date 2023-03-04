using System;


namespace ProjetoPista.Model.Entities
{
	public class Professores
	{
		public virtual int id_professor { get; set; }
		public virtual string nm_professor { get; set; }
		public virtual string cd_cpf { get; set; }
		public virtual string ds_telefone { get; set; }
		public virtual string ds_email { get; set; }
		public virtual string ds_instagram { get; set; }
		public virtual double nr_estrelas { get; set; }
		public virtual int nr_anos_experiencia { get; set; }
		public virtual string nm_apelido { get; set; }
		public virtual double vl_hora_aula { get; set; }
		public virtual int fl_ativo { get; set; }
		public virtual int id_status_aprovacao { get; set; }
		public virtual string nm_profile { get; set; }


	}


}
