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
            var aprovacoes = _pistaBusiness.FiltrarValidacao();

            return View("Consulta",aprovacoes);
        }

        public IActionResult Novo()
        {
            ViewData["Title"] = "Nova Pista";

            var pista = new PistaDto();
            pista.tamanhos = _pistaBusiness.ComboTamanho();
            pista.estados = _pistaBusiness.ComboEstado();
            pista.cidades = _pistaBusiness.ComboCidade();
            pista.status = _pistaBusiness.ComboStatus();
            pista.modalidades = _pistaBusiness.ComboModalidades();
            pista.niveis = _pistaBusiness.ComboNiveis();
            pista.modalidadesSelecionadas = _pistaBusiness.BuscaPistaModalidade(pista.id_pista);
            pista.niveisSelecionados = _pistaBusiness.BuscaPistaNiveis(pista.id_pista);

            var formData = new PistaDto
            {
                tamanhos = pista.tamanhos,
                cidades = pista.cidades,
                estados = pista.estados,
                status = pista.status,
                modalidades = pista.modalidades,
                niveis = pista.niveis

            };


            return View("Salvar", formData);
        }
        public IActionResult NovoNovo()
        {
            ViewData["Title"] = "Nova Pista";

            var pista = new PistaDto();
            pista.tamanhos = _pistaBusiness.ComboTamanho();
            pista.estados = _pistaBusiness.ComboEstado();
            pista.cidades = _pistaBusiness.ComboCidade();
            pista.status = _pistaBusiness.ComboStatus();
            pista.modalidades = _pistaBusiness.ComboModalidades();
            pista.niveis = _pistaBusiness.ComboNiveis();
            pista.modalidadesSelecionadas = _pistaBusiness.BuscaPistaModalidade(pista.id_pista);
            pista.niveisSelecionados = _pistaBusiness.BuscaPistaNiveis(pista.id_pista);

            var formData = new PistaDto
            {
                tamanhos = pista.tamanhos,
                cidades = pista.cidades,
                estados = pista.estados,
                status = pista.status,
                modalidades = pista.modalidades,
                niveis = pista.niveis

            };


            return View("SalvarNovo", formData);
        }
        [HttpPost]
        public ActionResult BuscaCidades(int estado)
        {
            var cidade = _pistaBusiness.ComboCidade(estado);

            return Json(new { cidade });
        }
        public IActionResult Editar(int id)
        {
            var pista = _pistaBusiness.Selecionar(id);
            pista.tamanhos = _pistaBusiness.ComboTamanho();

            var endereco = _pistaBusiness.SelecionarEndereco(pista.id_endereco);

            var CidEst = _pistaBusiness.SelecionarCidade(endereco.id_cidade);

            pista.estados = _pistaBusiness.ComboEstado();

            pista.cidades = _pistaBusiness.ComboCidade(CidEst.id_estado);

            pista.status = _pistaBusiness.ComboStatus();

            pista.modalidades = _pistaBusiness.ComboModalidades();

            pista.niveis = _pistaBusiness.ComboNiveis();
            pista.modalidadesSelecionadas = _pistaBusiness.BuscaPistaModalidade(pista.id_pista);

            pista.niveisSelecionados = _pistaBusiness.BuscaPistaNiveis(pista.id_pista);

            var usuario_envio = _pistaBusiness.SelecionarUsuarioEnvio(pista.id_usuario_envio);

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
                fl_cobertura = pista.fl_cobertura,

                //endereco
                id_endereco = endereco.id_endereco,
                ds_endereco = endereco.ds_endereco,
                nr_endereco = endereco.nr_endereco,
                cd_cep = endereco.cd_cep,

                //gambiarra temporaria da latitude
                latitude = endereco.nr_latitude.ToString(),
                longitude = endereco.nr_longitude.ToString(),

                id_cidade = CidEst.id_cidade,
                id_estado = CidEst.id_estado,

                tamanhos = pista.tamanhos,
                cidades = pista.cidades,
                estados = pista.estados,
                status = pista.status,
                modalidades = pista.modalidades,
                modalidadesSelecionadas = pista.modalidadesSelecionadas,
                niveis = pista.niveis,
                niveisSelecionados = pista.niveisSelecionados,

                id_usuario_envio = usuario_envio.id_usuario_envio,
                nm_usuario_envio = usuario_envio.nm_usuario_envio,
                nr_telefone = usuario_envio.nr_telefone,
                ds_email = usuario_envio.ds_email

                //cidade/estado
                /*id_cidade
                nm_cidade
                id_estado
                nm_estado

                //tamanhos
                id_tamanho
                ds_tamanho

                //modalidade
                id_modalidade
                nm_modalidade
                ds_modalidade

                //Status_aprovacao
                id_status_aprovacao
                ds_status_aprovacao

                //nivel_dificuldade
                id_nivel_dificuldade
                nm_nivel_dificuldade
                ds_nivel_dificuldade*/
            };


            ViewData["Title"] = "Aprovar Pista";
            //pista.tiposSelected = new SelectListItem { Value = pista.id_tamanho, Text = "Grande" };



            return View("Salvar", formData);
        }
        public IActionResult GerenciarImagens(int id)
        {
            ViewData["Title"] = "Nova Pista";
            //buscar imagens 
            var pista = _pistaBusiness.Selecionar(id);
            pista.nm_imagens = _pistaBusiness.BuscaImagens(id);

            var formData = new PistaDto
            {
                id_pista = id, 
                nm_imagens = pista.nm_imagens
            };
            ViewData["Title"] = pista.nm_pista;
            return View("ExcluirImagens", formData);
        }
        public IActionResult DeleteImagem(string imgdel, int id)
        {
            string nome = imgdel;
            imgdel = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\imagensPistas", imgdel);
            FileInfo fi = new FileInfo(imgdel);
            if (fi != null)
            {
                System.IO.File.Delete(imgdel);
                fi.Delete();
                var resultado = _pistaBusiness.ExcluirImagem(nome);
                if (!resultado.Sucesso) {  }


            }

            return RedirectToAction("GerenciarImagens", new { id = id });
        }

        [HttpPost]
        public IActionResult Salvar(PistaDto pistaDto)
        {
            pistaDto.nm_imagens = UploadedFile(pistaDto);
            //gambiarra temporaria de validação de latitude e longitude
            pistaDto.nr_latitude = Double.Parse(pistaDto.latitude);
            pistaDto.nr_longitude = Double.Parse(pistaDto.longitude);
            var resultado = _pistaBusiness.Salvar(pistaDto);

            //var resultado = '';
            return RedirectToAction("Consultar", "Aprovacoes");

        }

        private string[] UploadedFile(PistaDto model)
        {
            string uniqueFileName = null;
            List<string> nomes = new List<string>();
            if(model.imagens_pista != null) { 
            foreach (var item in model.imagens_pista)
            {
                if (item != null)
                {
                    string uploadsFolder = Path.Combine(_hostEnvironment.ContentRootPath, "wwwroot\\imagensPistas");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + item.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    Directory.CreateDirectory(uploadsFolder);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        item.CopyTo(fileStream);
                    }
                    nomes.Add(uniqueFileName);
                }
            }
            }

            return nomes.ToArray();
        }

        public IActionResult Excluir(int id)
        {
            var resultado = _pistaBusiness.Excluir(id);
            return Json(new ResultadoViewModel
            {
                Sucesso = resultado.Sucesso,
                Url = Url.Action("Consultar")
            });
        }
        public IActionResult VerificaNome(string nm_pista,int id_pista)
        {
             var usuario = this._pistaBusiness.VerificaNome(nm_pista,id_pista);

            if (usuario == null)
            {
                return Json(data: true);
            }
            else
            {
                return Json(data: "Esse nome já está sendo utilizado, tente colocar mais alguma informação de Local. Ex: PistaTal (Campinas)");
            }

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
       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveUploadedFile(IFormFile[] files)
        {
            bool SavedSuccessfully = true;
            //string fName = "";
            try
            {
                string uploads = Path.Combine(_hostEnvironment.ContentRootPath, "files");
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
                return RedirectToAction("Novo", new { Message = "All files saved successfully" });
            }
            else
            {
                return RedirectToAction("Novo", new { Message = "Error in saving file" });
            }


            //return PartialView("SalvarImagens");
        }
    }
}