using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProjetoPista.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Interfaces;
using ProjetoPista.WebApp.Models;
using Microsoft.Extensions.Hosting;

namespace ProjetoPista.WebApp.Controllers
{
    
    public class HomeController : Controller
    {

        private readonly IPistaBusiness _pistaBusiness;
        //private readonly IUsuarioBusiness _usuarioBusiness;
        private readonly IHostEnvironment _hostEnvironment;
        public HomeController(IPistaBusiness pistaBusiness, IHostEnvironment hostEnvironment)
        {
            this._pistaBusiness = pistaBusiness;
            this._hostEnvironment = hostEnvironment;

        }
        public IActionResult Index()
        {
            var pistas = _pistaBusiness.FiltrarPistas();
            ViewBag.id_pista = null;
            ViewBag.Estado = _pistaBusiness.ComboEstado();
            ViewBag.Cidade = _pistaBusiness.ComboCidade();
            ViewBag.Modalidades = _pistaBusiness.ComboModalidades();
            ViewBag.Dificuldade = _pistaBusiness.ComboNiveis();


            return View(pistas);
        }
        public IActionResult Cadastros()
        {
            return View();
        }
        public IActionResult Sobre()
        {
            return View();
        }
        

        public ActionResult Details(int id)
        {
            var pista = _pistaBusiness.Selecionar(id);

            var formData = new PistaDto
            {
                id_pista = pista.id_pista,
                nm_pista = pista.nm_pista,
                ds_pista = pista.ds_pista,
                fl_paga = pista.id_pista,
                ds_horario_funcionamento = pista.ds_horario_funcionamento,
                fl_pista_ativa = pista.fl_pista_ativa,
                fl_capacete = pista.fl_capacete,
                fl_aluga_capacete = pista.fl_aluga_capacete,
                nr_nota = pista.nr_nota,
                ds_notas_gerais = pista.ds_notas_gerais,
                id_tamanho = pista.id_tamanho,
                id_status_aprovacao = pista.id_status_aprovacao,

            };

            return PartialView("ModalPista",formData);
        }
        [HttpPost]
        public IActionResult FiltrarPista(PistaFiltroDto pistasFiltro)
        {
            var pistaFilt = _pistaBusiness.FiltrarPistas(pistasFiltro);
            //alimentar viewbag com os filtros aplicados
            ViewBag.nm_pista = pistasFiltro.nm_pista;
            ViewBag.Estado = _pistaBusiness.ComboEstado();
            ViewBag.Cidade = _pistaBusiness.ComboCidade();
            ViewBag.Dificuldade = _pistaBusiness.ComboNiveis();
            ViewBag.Modalidades = _pistaBusiness.ComboModalidades();

            if (pistaFilt.Count() == 0)
            { 
                ViewBag.Nenhum = "Os filtros não retornaram nenhuma pista :(";
                pistaFilt = _pistaBusiness.FiltrarPistas();
            }
            return View("Index", pistaFilt);
        }
        [HttpPost]
        public IActionResult NearMe(double lat,double lon)
        {
            var pistaFilt = _pistaBusiness.FiltrarPistasPerto(lat,lon);
            if (pistaFilt.Count() == 0)
            {
                ViewBag.Nenhum = "Os filtros não retornaram nenhuma pista :( Tente novamente mais tarde";
                pistaFilt = _pistaBusiness.FiltrarPistas();
            }
            ViewBag.lat = lat.ToString();
            ViewBag.lon = lon.ToString();
            return PartialView("Mapa", pistaFilt);
        }
    }
}
