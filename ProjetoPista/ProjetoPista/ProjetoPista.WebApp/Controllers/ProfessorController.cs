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
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;


namespace ProjetoPista.WebApp.Controllers
{
    [Authorize]
    public class ProfessorController : Controller
    {

        private readonly IProfessorBusiness _professorBusiness;
        //private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IHostEnvironment _hostEnvironment;
        public ProfessorController(IProfessorBusiness professorBusiness, IHostEnvironment hostEnvironment)
        {
            this._professorBusiness = professorBusiness;
            this._hostEnvironment = hostEnvironment;

        }

        [Authorize]
        public IActionResult Consultar()
        {
            var professores = _professorBusiness.Filtrar();

            return View("Consulta", professores);
        }
        
        public IActionResult Novo()
        {
            ViewData["Title"] = "Nova Pista";

            var professor = new ProfessorDto();
            professor.pistas = _professorBusiness.ComboPistas();
            

            var formData = new ProfessorDto
            {
                pistas = professor.pistas
            };


            return View("Salvar", formData);
        }
        
        
        public IActionResult Editar(int id)
        {
            var professor = _professorBusiness.SelecionarProfessor(id);
            professor.status= _professorBusiness.ComboStatus();

            professor.pistas = _professorBusiness.ComboPistas();
            professor.ids_pistas_professor = _professorBusiness.BuscaPistaProfessor(id);

            var formData = new ProfessorDto
            {
                id_professor = professor.id_professor,
                nm_professor = professor.nm_professor,
                cd_cpf = professor.cd_cpf,
                ds_instagram = professor.ds_instagram,
                ds_telefone = professor.ds_telefone,
                ds_email = professor.ds_email,
                nm_apelido = professor.nm_apelido,
                nr_estrelas = professor.nr_estrelas,
                nr_anos_experiencia= professor.nr_anos_experiencia,
                fl_ativo = professor.fl_ativo,
                vl_hora_aula = professor.vl_hora_aula,
                id_status_aprovacao = professor.id_status_aprovacao,
                ids_pistas_professor = professor.ids_pistas_professor,
                pistas = professor.pistas,
                status = professor.status,
                nm_profile = professor.nm_profile
                
                
            };


            ViewData["Title"] = "Aprovar Professor";
            //pista.tiposSelected = new SelectListItem { Value = pista.id_tamanho, Text = "Grande" };



            return View("Salvar", formData);
        }
        
        
        [HttpPost]
        public IActionResult Salvar(ProfessorDto professorDto)
        {

            string uniqueFileName = UploadedFile(professorDto);

            professorDto.nm_profile = uniqueFileName;

            var resultado = _professorBusiness.Salvar(professorDto);

            //var resultado = '';
            return RedirectToAction("Consultar", "Professor");

        }

        public IActionResult VerificaProf(ProfessorDto professorDto)    
        {
            var texto = this._professorBusiness.VerificaProf(professorDto);

            if (texto == "true")
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: texto);
            }

        }
        public IActionResult DeleteImagem(string imgdel)
        {
            imgdel = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\imagensProf",imgdel);
            FileInfo fi = new FileInfo(imgdel);
            if (fi!=null)
            {
                System.IO.File.Delete(imgdel);
                fi.Delete();
            }

            return RedirectToAction("Salvar","Professor");
        }

        private string UploadedFile(ProfessorDto model)
        {
            string uniqueFileName = null;

            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\imagensProf");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                Directory.CreateDirectory(uploadsFolder);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
        /*
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
        [ValidateAntiForgeryToken]
        public JsonResult InsertPhotos()
        {
            if (Request.Form.Files.Count > 0)
            {
                for (int i = 0; i < Request.Form.Files.Count; i++)
                {
                    //process files
                }
            }

            //return some result
            return Json(new Newtonsoft.Json.JsonSerializerSettings());
        }
       */
    }
}