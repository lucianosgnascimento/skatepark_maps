using System;


namespace ProjetoPista.Model.Entities
{
	public class Endereco
	{
		public virtual int id_endereco { get; set; }
		public virtual string ds_endereco { get; set; }
		public virtual string nr_endereco { get; set; }
		public virtual string cd_cep { get; set; }
		public virtual decimal nr_latitude { get; set; }
		public virtual decimal nr_longitude { get; set; }
		public virtual int id_cidade { get; set; }
		

		
	}


}
