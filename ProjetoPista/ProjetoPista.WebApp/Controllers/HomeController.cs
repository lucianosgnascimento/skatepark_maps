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
        //private readonly IProfessorBusiness _professorBusiness;
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
            ViewBag.PistaModel = "0";
            ViewBag.ProfessorModel = "0";


            return View(pistas);
        }
        public IActionResult IndexSecond(int id)
        {
            var pistas = _pistaBusiness.FiltrarPistas();
            ViewBag.id_pista = null;
            ViewBag.Estado = _pistaBusiness.ComboEstado();
            ViewBag.Cidade = _pistaBusiness.ComboCidade();
            ViewBag.Modalidades = _pistaBusiness.ComboModalidades();
            ViewBag.Dificuldade = _pistaBusiness.ComboNiveis();
            ViewBag.PistaModel = id ;
            ViewBag.ProfessorModel = "0";



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

        public PistaDto PistaModel(int id)
        {

            var pista = _pistaBusiness.Selecionar(id);

            var PistaO = new PistaDto
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

            return PistaO;
        }

        public ActionResult Details(int id)
        {
            var pista = _pistaBusiness.SelecionarPistaFull(id);
            

            var formData = new PistaFullDto
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
                modalidadesSelecionadas = pista.modalidadesSelecionadas,
                niveisSelecionados = pista.niveisSelecionados,
                ds_endereco = pista.ds_endereco,
                cd_cep = pista.cd_cep,
                nm_cidade = pista.nm_cidade,
                nm_estado = pista.nm_estado,
                nr_endereco = pista.nr_endereco,
                professores = pista.professores,
                nm_imagens = pista.nm_imagens

            };

            return PartialView("PistaInfo",formData);
        }

        public IActionResult Pista(int id)
        {
            var pistas = _pistaBusiness.FiltrarPistas();
            ViewBag.id_pista = null;
            ViewBag.Estado = _pistaBusiness.ComboEstado();
            ViewBag.Cidade = _pistaBusiness.ComboCidade();
            ViewBag.Modalidades = _pistaBusiness.ComboModalidades();
            ViewBag.Dificuldade = _pistaBusiness.ComboNiveis();
            ViewBag.PistaModel = id.ToString();


            return View("Index",pistas);
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

        public IActionResult FiltraPistasProf(int id)
        {
            var pistaProf = _pistaBusiness.FiltrarPistasProf(id);
            
            return PartialView("Mapa", pistaProf);
        }

        [HttpPost]
        public IActionResult FiltrarPistaHome(PistaFiltroHomeDto pistasFiltro)
        {

            List<int> modalidadesSelecionadas = new List<int>();
            List<int> niveisSelecionados = new List<int>();

            if (pistasFiltro.fl_vert) { modalidadesSelecionadas.Add(1); }
            if (pistasFiltro.fl_street) { modalidadesSelecionadas.Add(2); }
            if (pistasFiltro.fl_half) { modalidadesSelecionadas.Add(3); }
            if (pistasFiltro.fl_hill) { modalidadesSelecionadas.Add(5); }
            if (pistasFiltro.fl_plaza) { modalidadesSelecionadas.Add(6); }
            if (pistasFiltro.fl_facil) { niveisSelecionados.Add(1); niveisSelecionados.Add(2); }
            if (pistasFiltro.fl_medio) { niveisSelecionados.Add(2); niveisSelecionados.Add(3); }
            if (pistasFiltro.fl_medio) { niveisSelecionados.Add(2); niveisSelecionados.Add(3); }
            if (pistasFiltro.fl_dificil) { niveisSelecionados.Add(3); niveisSelecionados.Add(4); niveisSelecionados.Add(5); }

            var pistaFiltRaw = new PistaFiltroDto
            {
                nm_pista = pistasFiltro.nm_pista,
                id_cidade = pistasFiltro.id_cidade,
                id_estado = pistasFiltro.id_estado,
                modalidadesSelecionadas = modalidadesSelecionadas,
                niveisSelecionados = niveisSelecionados
            };

            var pistaFilt = _pistaBusiness.FiltrarPistas(pistaFiltRaw);
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
            return PartialView("Mapa", pistaFilt);
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
