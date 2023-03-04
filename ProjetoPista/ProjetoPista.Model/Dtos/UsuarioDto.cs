using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace ProjetoPista.Model.Dtos
{
    public class UsuarioDto
    {

        public int IdUsuario { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Nome")]
        public string Nome { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o Email")]
        [Remote(action: "VerificaEmail", controller: "Usuario")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe o login")]
        [Remote(action: "VerificaLogin", controller: "Usuario")]
        public string Login { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Informe a Senha")]
        public string Senha { get; set; }
    }
}
