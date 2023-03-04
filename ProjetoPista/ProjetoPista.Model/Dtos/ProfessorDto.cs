using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ProjetoPista.Model.Dtos
{
    public class ProfessorDto
	{
		public int id_professor { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Nome")]
		[MaxLength(45)]
		public string nm_professor { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Cpf")]
		[Remote(action: "VerificaProf", controller: "Professor",AdditionalFields = "id_professor")]
		[MinLength(11)]
		[MaxLength(15)]
		public string cd_cpf { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Telefone")]
		[Remote(action: "VerificaProf", controller: "Professor", AdditionalFields = "id_professor")]
		[MinLength(11)]
		[MaxLength(12)]
		public string ds_telefone { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Email")]
		[MaxLength(45)]
		[Remote(action: "VerificaProf", controller: "Professor", AdditionalFields = "id_professor")]
		public string ds_email { get; set; }
		[MaxLength(45)]
		public string ds_instagram { get; set; }
		public double nr_estrelas { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o numero de anos")]
		[Range(1, 30, ErrorMessage = "Informe um numero de anos de experiência")]
		public int nr_anos_experiencia { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Apelido")]
		[MaxLength(45)]
		[Remote(action: "VerificaProf", controller: "Professor", AdditionalFields = "id_professor")]
		public string nm_apelido { get; set; }
		public double vl_hora_aula { get; set; }
		public int fl_ativo { get; set; }
		public int id_status_aprovacao { get; set; }
		public int id_pista_professor { get; set; }
		public int id_pista { get; set; }
		public string nm_pista { get; set; }
		[Required(AllowEmptyStrings = false, ErrorMessage = "Selecione pelo menos uma pista em que você da aula")]
		public IEnumerable<int> ids_pistas_professor { get; set; }
		public bool BoolAtivo
		{
			get { return fl_ativo == 1; }
			set { fl_ativo = value ? 1 : 0; }
		}
		public IEnumerable<SelectListItem> status { get; set; }
		public IEnumerable<SelectListItem> pistas { get; set; }

		//[Required(ErrorMessage = "Selecione uma imagem de perfil")]
		[Display(Name = "Profile Picture")]
		public IFormFile ProfileImage { get; set; }
		[MaxLength(256)]
		public string nm_profile { get; set; }
		//fotos

		//********
		public int id_cidade { get; set; }
		public string nm_cidade { get; set; }
		public int id_estado { get; set; }


		/*
		public IEnumerable<int> niveisSelecionados { get; set; }
		

		public IEnumerable<SelectListItem> modalidades { get; set; }
		public IEnumerable<SelectListItem> niveis { get; set; }

		public IEnumerable<SelectListItem> estados { get; set; }
		public IEnumerable<SelectListItem> cidades { get; set; }
		
		*/


	}
}
