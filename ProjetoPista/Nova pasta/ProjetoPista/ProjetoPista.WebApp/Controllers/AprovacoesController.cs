using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Interfaces;
using ProjetoPista.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Hosting;
using System;

namespace ProjetoPista.WebApp.Controllers
{
    [Authorize]
    public class AprovacoesController : Controller
    {

        private readonly IPistaBusiness _pistaBusiness;
        //private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IHostEnvironment _hostEnvironment;
        public AprovacoesController(IPistaBusiness pistaBusiness, IHostEnvironment hostEnvironment)
        {
            this._pistaBusiness = pistaBusiness;
            this._hostEnvironment = hostEnvironment;

        }

        [Authorize]
        public IActionResult Consultar()
        {
            var aprovacoes = _pistaBusiness.Filtrar();

            return View("Consulta",aprovacoes);
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Nova aprovacoes";
            return View("SalvarImagens", new PistaDto());
        }

        public IActionResult Editar(int id)
        {
            var pista = _pistaBusiness.Selecionar(id);
            pista.tamanhos = _pistaBusiness.BuscaTamanho();
            ViewData["Title"] = "Editar aprovacoes";
            //pista.tiposSelected = new SelectListItem { Value = pista.id_tamanho, Text = "Grande" };



            return View("Salvar", pista);
        }

        
        [HttpPost]
        /*public IActionResult Salvar(PistaDto pistaDto)
        {
            var resultado = _pistaBusiness.Salvar(pistaDto);
            var resultado = '';
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Id = resultado.Id,
                Url = Url.Action("Consultar")
            });
           
        }*/
        
        public IActionResult Excluir(int id)
        {
            var resultado = _pistaBusiness.Excluir(id);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Url = Url.Action("Consultar")
            });
        }

        [HttpPost]
        public ActionResult SaveUploadedFile(IEnumerable<IFormFile> files)
        {
            bool SavedSuccessfully = true;
            //string fName = "";
            try
            {
                string uploads = Path.Combine(_hostEnvironment.ContentRootPath, "Uploads");
                //Create directory if it doesn't exist 
                Directory.CreateDirectory(uploads);
                foreach (IFormFile file in files)
                {
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(uploads, file.FileName);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                        {
                            file.CopyTo(fileStream);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                SavedSuccessfully = false;
            }


            if (SavedSuccessfully)
            {
                return RedirectToAction("Index", new { Message = "All files saved successfully" });
            }
            else
            {
                return RedirectToAction("Index", new { Message = "Error in saving file" });
            }


            //return PartialView("SalvarImagens");
        }
    }
}