using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ProjetoPista.Model.Dtos
{

	public class PistaFiltroDto
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
		public int nr_endereco { get; set; }
		public string cd_cep { get; set; }
		public double nr_latitude { get; set; }
		public double nr_longitude { get; set; }

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
		public int id_nivel_dificuldade { get; set; }
		public string nm_nivel_dificuldade { get; set; }
		public string ds_nivel_dificuldade { get; set; }

		public string[] nm_imagens { get; set; }
		public IFormFile[] imagens_pista { get; set; }


		//fotos

		//********



		public IEnumerable<int> modalidadesSelecionadas { get; set; }
		public IEnumerable<int> niveisSelecionados { get; set; }

		public IEnumerable<SelectListItem> tamanhos { get; set; }

		public IEnumerable<SelectListItem> modalidades { get; set; }
		public IEnumerable<SelectListItem> niveis { get; set; }

		public IEnumerable<SelectListItem> estados { get; set; }
		public IEnumerable<SelectListItem> cidades { get; set; }
		public IEnumerable<SelectListItem> status { get; set; }

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

		public bool BoolCapacete
		{
			get { return fl_capacete == 1; }
			set { fl_capacete = value ? 1 : 0; }
		}

		public bool BoolAluga
		{
			get { return fl_aluga_capacete == 1; }
			set { fl_aluga_capacete = value ? 1 : 0; }
		}

	}
}
