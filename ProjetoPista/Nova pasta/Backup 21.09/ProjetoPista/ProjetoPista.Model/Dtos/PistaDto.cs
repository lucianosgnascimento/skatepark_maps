using System;
using System.Collections.Generic;
using System.Text;
namespace ProjetoPista.Model.Dtos
{
    public class PistaDto
    {
		public int id_pista { get; set; }
		public string nm_pista { get; set; }
		public string ds_pista { get; set; }
		public int fl_paga { get; set; }
		public string ds_horario_funcionamento { get; set; }
		public int fl_pista_ativa { get; set; }
		public int fl_capacete { get; set; }
		public int fl_aluga_capacete { get; set; }
		public int nr_nota { get; set; }
		
		public string ds_notas_gerais { get; set; }


		//endereco
		public int id_endereco { get; set; }
		public string ds_endereco { get; set; }
		public string nr_endereco { get; set; }
		public string cd_cep { get; set; }
		public decimal nr_latitude { get; set; }
		public decimal nr_longitude { get; set; }

		//cidade/estado
		public int id_cidade { get; set; }
		public string nm_cidade { get; set; }
		public int id_estado { get; set; }
		public string nm_estado { get; set; }


		//tamanhos
		public int id_tamanho { get; set; }
		public int ds_tamanho { get; set; }


		//modalidade
		public int id_modalidade { get; set; }
		public string nm_modalidade { get; set; }
		public string ds_modalidade { get; set; }

		//Status_aprovacao
		public int id_status_aprovacao { get; set; }
		public string ds_status_aprovacao { get; set; }

		//nivel_dificuldade
		public virtual int id_nivel_dificuldade { get; set; }
		public virtual string nm_nivel_dificuldade { get; set; }
		public virtual string ds_nivel_dificuldade { get; set; }


		//fotos

		//********




		public IEnumerable<SelectListItem> tamanhos { get; set; }
		public IEnumerable<SelectListItem> estados { get; set; }
		public IEnumerable<SelectListItem> cidades { get; set; }


		public bool BoolPaga
		{
			get { return fl_paga == 1; }
			set { fl_paga = value ? 1 : 0; }
		}
		public bool BoolAtiva
		{
			get { return fl_pista_ativa == 1; }
			set { fl_pista_ativa = value ? 1 : 0; }
		}
	}
}
