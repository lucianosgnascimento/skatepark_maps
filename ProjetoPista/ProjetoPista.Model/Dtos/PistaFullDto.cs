using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ProjetoPista.Model.Dtos
{

	public class PistaFullDto
	{

		public int id_pista { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome da Pista")]
		[MaxLength(100)]
		[Remote(action: "VerificaNome", controller: "Aprovacoes", AdditionalFields = "id_pista")]
		public string nm_pista { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe uma descrição para a Pista")]
		[MaxLength(700)]
		public string ds_pista { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe se a pista é paga")]
		public int fl_paga { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o horário de funcionamento da Pista")]
		[MaxLength(128)]
		public string ds_horario_funcionamento { get; set; }
		public int fl_pista_ativa { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe a obrigatoriedade de capacete da Pista")]
		public int fl_capacete { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe se aluga capacete na Pista")]
		public int fl_aluga_capacete { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe uma nota para a Pista")]
		[Range(1, 10, ErrorMessage = "Informe uma nota para a Pista de 1 a 10")]
		public int nr_nota { get; set; }

		[MaxLength(400)]
		public string ds_notas_gerais { get; set; }


		//endereco
		public int id_endereco { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o endereço da Pista")]
		[MaxLength(256)]
		public string ds_endereco { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o número do endereço da Pista")]
		[Range(1, 100000, ErrorMessage = "Informe um numero válido para o endereço da Pista")]
		public int nr_endereco { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe um CEP válido da Pista")]
		[MinLength(7)]
		[MaxLength(10)]
		public string cd_cep { get; set; }
		//[Required(AllowEmptyStrings = false, ErrorMessage = "Informe a Latitude da Pista")]
		public double nr_latitude { get; set; }
		//[Required(AllowEmptyStrings = false, ErrorMessage = "Informe a Longitude da Pista")]
		public double nr_longitude { get; set; }
		public string latitude { get; set; }
		public string longitude { get; set; }
		public double nr_distancia { get; set; }
		public virtual int fl_cobertura { get; set; }

		//cidade/estado
		public int id_cidade { get; set; }
		public string nm_cidade { get; set; }
		public int id_estado { get; set; }
		public string nm_estado { get; set; }


		//tamanhos
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o tamanho da Pista")]
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


		public int id_usuario_envio { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o nome")]
		public string nm_usuario_envio { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o telefone")]
		public string nr_telefone { get; set; }
		public string ds_email { get; set; }


		//fotos

		//********


		public IEnumerable<ProfessorDto> professores { get; set; }


		[Required(AllowEmptyStrings = false, ErrorMessage = "Selecione pelo menos 1 modalidade para a Pista")]
		public IEnumerable<String> modalidadesSelecionadas { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Selecione pelo menos 1 nível de dificuldade para a Pista")]
		public IEnumerable<string> niveisSelecionados { get; set; }



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
		public bool BoolCobertura
		{
			get { return fl_cobertura == 1; }
			set { fl_cobertura = value ? 1 : 0; }
		}
	}
}