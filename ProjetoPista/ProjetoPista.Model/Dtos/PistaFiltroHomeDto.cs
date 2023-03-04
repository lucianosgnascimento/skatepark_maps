using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace ProjetoPista.Model.Dtos
{

	public class PistaFiltroHomeDto
	{

		
		public string nm_pista { get; set; }
		public int id_cidade { get; set; }
		public int id_estado { get; set; }
		public bool fl_street { get; set; }
		public bool fl_vert { get; set; }
		public bool fl_plaza { get; set; }
		public bool fl_half { get; set; }
		public bool fl_hill { get; set; }
		public bool fl_facil { get; set; }
		public bool fl_medio { get; set; }
		public bool fl_dificil { get; set; }




	}
}
