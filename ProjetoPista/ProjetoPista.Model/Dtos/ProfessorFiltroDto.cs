using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ProjetoPista.Model.Dtos
{
    public class ProfessorFiltroDto
	{
		public int id_professor { get; set; }
		public string nm_professor { get; set; }
		//[Remote(action: "VerificaProf", controller: "Professor")]
		[MinLength(11)]
		public string cd_cpf { get; set; }
		//[Remote(action: "VerificaProf", controller: "Professor")]
		[MinLength(11)]
		public string ds_telefone { get; set; }
		//[Remote(action: "VerificaProf", controller: "Professor")]
		public string ds_email { get; set; }
		public string ds_instagram { get; set; }
		public double nr_estrelas { get; set; }

		public int nr_anos_experiencia { get; set; }

		//[Remote(action: "VerificaProf", controller: "Professor")]
		public string nm_apelido { get; set; }
		public double vl_hora_aula { get; set; }
		public int fl_ativo { get; set; }
		public int id_status_aprovacao { get; set; }
		public int id_pista_professor { get; set; }
		public int id_pista { get; set; }
		public string nm_pista { get; set; }
		public IEnumerable<int> ids_pistas_professor { get; set; }
		public bool BoolAtivo
		{
			get { return fl_ativo == 1; }
			set { fl_ativo = value ? 1 : 0; }
		}
		public IEnumerable<SelectListItem> status { get; set; }
		public IEnumerable<SelectListItem> pistas { get; set; }

		//[Required(ErrorMessage = "Selecione uma imagem de perfil")]
		public IFormFile ProfileImage { get; set; }

		public string nm_profile { get; set; }
		//fotos

		//********



		/*
		public IEnumerable<int> niveisSelecionados { get; set; }
		

		public IEnumerable<SelectListItem> modalidades { get; set; }
		public IEnumerable<SelectListItem> niveis { get; set; }

		public IEnumerable<SelectListItem> estados { get; set; }
		public IEnumerable<SelectListItem> cidades { get; set; }
		
		*/


	}
}
