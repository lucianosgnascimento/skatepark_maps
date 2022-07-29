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
using X.PagedList.Mvc.Core;
using X.PagedList;

namespace ProjetoPista.WebApp.Controllers
{
    
    public class DashProfessorController : Controller
    {
        private readonly IProfessorBusiness _professorBusiness;
        private readonly IPistaBusiness _pistaBusiness;

        //private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IHostEnvironment _hostEnvironment;
        public DashProfessorController(IProfessorBusiness professorBusiness, IPistaBusiness pistaBusiness, IHostEnvironment hostEnvironment)
        {
            this._professorBusiness = professorBusiness;
            this._hostEnvironment = hostEnvironment;
            this._pistaBusiness = pistaBusiness;

        }
        public IActionResult Index()
        {
            var professores = _professorBusiness.Filtrar();
            ViewBag.nm_professor = null;
            ViewBag.pistas = _professorBusiness.ComboPistas();
            ViewBag.id_pista = null;
            ViewBag.Estado = _pistaBusiness.ComboEstado();
            ViewBag.Cidade = _pistaBusiness.ComboCidade();

            return View("Index", professores.ToPagedList(1, 1));
        }
        public ActionResult BuscaCidades(int estado)
        {
            var cidade = _pistaBusiness.ComboCidade(estado);

            return Json(new { cidade });
        }
        public IActionResult Profile()
        {
            return View("Professor");
        }
        public IActionResult Consultar(string sortOrder, string currentFilter, string searchString, int? page, string nm_professor)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentSort = sortOrder;
            ViewBag.CurrentFilter = searchString;
            ViewBag.nm_professor = nm_professor;
            var professores = _professorBusiness.Filtrar();
            int pageSize = 1;
            int pageNumber = (page ?? 1);
            return View("Index", professores.ToPagedList(pageNumber, pageSize));
        }

        [HttpPost]
        public IActionResult Filtrar(ProfessorFiltroDto professores)
        {
            var professoresFilt = _professorBusiness.BuscaProfessorFiltrado(professores);
            //alimentar viewbag com os filtros aplicados
            ViewBag.nm_professor = professores.nm_professor;
            return View("Index", professoresFilt.ToPagedList(1,2));
        }

    }
}
