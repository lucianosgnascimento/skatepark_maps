using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoPista.WebApp.Controllers
{
    
    public class SecureController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public SecureController(IUsuarioBusiness usuarioBusiness)
        {
            this._usuarioBusiness = usuarioBusiness;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            var model = new LoginDto();
            return View(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var usuario = this._usuarioBusiness.Autenticar(model);

                if (usuario != null)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, usuario.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim(ClaimTypes.GivenName, usuario.Login)
                    };

                    var identity = new ClaimsIdentity(claims, "CookieAuth");
                    var principal = new ClaimsPrincipal(identity);
                    

                    await HttpContext.SignInAsync("CookieAuth", principal);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model = new LoginDto();

                    TempData["ErroAutenticacao"] = "Usuário ou senha inválido";
                    return View(model);
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CookieAuth");
            return RedirectToAction("Login", "Secure");
        }
    }
}
