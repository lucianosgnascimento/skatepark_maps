using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Interfaces;
using ProjetoPista.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;


namespace ProjetoPista.WebApp.Controllers
{

    public class UsuarioController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Consultar()
        {
            var usuarios = _usuarioBusiness.Filtrar();

            return View(usuarios);
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Novo Usuário";
            return View("Salvar", new UsuarioDto());
        }

        public IActionResult Editar(int id)
        {
            var usuario = _usuarioBusiness.Selecionar(id);
            ViewData["Title"] = "Editar Usuário";
            return View("Salvar", usuario);
        }

        [HttpPost]
        public IActionResult Salvar(UsuarioDto usuarioDto)
        {
            if (ModelState.IsValid)
            {
                var resultado = _usuarioBusiness.Salvar(usuarioDto);
                return RedirectToAction("Consultar", "Usuario");
            }
            return View(usuarioDto);
        }

        [AcceptVerbs("GET", "POST")]
        public IActionResult VerificaEmail(string email)
        {
            var usuario = this._usuarioBusiness.VerificaEmail(email);

            if (usuario == null)
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: "Esse Email já está sendo utilizado");
            }

        }
        public IActionResult VerificaLogin(string login)
        {
            var usuario = this._usuarioBusiness.VerificaLogin(login);

            if (usuario == null)
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: "Esse Login já está sendo utilizado");
            }

        }

        public IActionResult Excluir(int id)
        {
            var resultado = _usuarioBusiness.Excluir(id);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Url = Url.Action("Consultar")
            });
        }
    }
}