using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Data;
using ProjetoPista.Utils;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace ProjetoPista.Business
{
    public class PistaBusiness : IPistaBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        



        public PistaBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public double ToRadians(double degrees) => degrees * Math.PI / 180.0;
        public double distanceInMiles(double lon1d, double lat1d, double lon2d, double lat2d)
        {
            var lon1 = ToRadians(lon1d);
            var lat1 = ToRadians(lat1d);
            var lon2 = ToRadians(lon2d);
            var lat2 = ToRadians(lat2d);

            var deltaLon = lon2 - lon1;
            var c = Math.Acos(Math.Sin(lat1) * Math.Sin(lat2) + Math.Cos(lat1) * Math.Cos(lat2) * Math.Cos(deltaLon));
            var earthRadius = 3958.76;
            var distInMiles = earthRadius * c;

            return distInMiles;
        }

        public IEnumerable<PistaDto> Filtrar()
        {
            var query = this._unitOfWork
                .PistaRepository
                
                .Get(null, o => o.OrderBy(u => u.nm_pista))
                .Select(s => new PistaDto
                {
                    id_pista = s.ID_pista,
                    nm_pista = s.nm_pista,
                    ds_pista = s.ds_pista,
                    nr_latitude = -23.6376677026326,
                    nr_longitude = -46.661345945319
                })
                ;
            return query.ToList();

        }
        public IEnumerable<PistaDto> FiltrarPistas()
        {
            var pista = this._unitOfWork.PistaRepository;
            var endereco = this._unitOfWork.EnderecoRepository;
            var cidade = this._unitOfWork.CidadeRepository;
            var PistaModalidade = this._unitOfWork.ModalidadePistaRepository;

            var PistaEndereco = pista.GetAll().Join(endereco.GetAll(),
                        p => p.id_endereco,
                        e => e.id_endereco,
                        (pist, end) =>
                        new PistaDto
                        {
                            id_pista = pist.ID_pista,
                            id_endereco = end.id_endereco,
                            ds_endereco = end.ds_endereco,
                            cd_cep = end.cd_cep,
                            nm_cidade = "SP",
                            nm_estado = "sp",
                            id_cidade = end.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = end.nr_latitude,
                            nr_longitude = end.nr_longitude,
                            modalidadesSelecionadas = this._unitOfWork.ModalidadePistaRepository.Get(null, o => o.OrderBy(u => u.id_modalidade_pista)).Where(o => o.id_pista.Equals(pist.ID_pista)).Select(s => s.id_modalidade).ToArray()


        });


            return PistaEndereco.ToList();
        }
        public IEnumerable<PistaDto> FiltrarPistasPerto(double lat,double lon)
        {
            var pista = this._unitOfWork.PistaRepository;
            var endereco = this._unitOfWork.EnderecoRepository;
            var cidade = this._unitOfWork.CidadeRepository;


            var radiusInMile = 15;
            var minMilePerLat = 68.703;
            var milePerLon = Math.Cos(lat) * 69.172;
            var minLat = lat - radiusInMile / minMilePerLat;
            var maxLat = lat + radiusInMile / minMilePerLat;
            var minLon = lon - radiusInMile / milePerLon;
            var maxLon = lon + radiusInMile / milePerLon;

            var PistaEndereco = pista.GetAll().Join(endereco.GetAll(),
                        p => p.id_endereco,
                        e => e.id_endereco,
                        (pist, end) =>
                        new PistaDto
                        {
                            id_pista = pist.ID_pista,
                            id_endereco = end.id_endereco,
                            id_cidade = end.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = end.nr_latitude,
                            nr_longitude = end.nr_longitude

                        }).AsQueryable()
                        .Where(p => (minLat <= p.nr_latitude && p.nr_latitude <= maxLat) && (minLon <= p.nr_longitude && p.nr_longitude <= maxLon))
                        .AsEnumerable()
                        .Select(s => new PistaDto
                        {
                            id_pista = s.id_pista,
                            id_endereco = s.id_endereco,
                            id_cidade = s.id_cidade,
                            ds_pista = s.ds_pista,
                            nm_pista = s.nm_pista,
                            ds_horario_funcionamento = s.ds_horario_funcionamento,
                            nr_latitude = s.nr_latitude,
                            nr_longitude = s.nr_longitude,
                            nr_distancia = distanceInMiles(lon, lat, s.nr_longitude, s.nr_latitude)
                        }).AsQueryable();

            PistaEndereco = PistaEndereco
                        .Where(p => p.nr_distancia <= radiusInMile);
            ;


            return PistaEndereco.ToList();
        }
        public IEnumerable<PistaDto> FiltrarPistas(PistaFiltroDto pistaFiltro)
        {
            var pista = this._unitOfWork.PistaRepository;
            var endereco = this._unitOfWork.EnderecoRepository;
            var cidade = this._unitOfWork.CidadeRepository;

            var PistaEndereco = pista.GetAll().Join(endereco.GetAll(),
                        p => p.id_endereco,
                        e => e.id_endereco,
                        (pist, end) =>
                        new PistaDto
                        {
                            id_pista = pist.ID_pista,
                            id_endereco = end.id_endereco,
                            id_cidade = end.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = end.nr_latitude,
                            nr_longitude = end.nr_longitude,
                            fl_pista_ativa = pist.fl_pista_ativa

                        })
                        .Where(o => o.fl_pista_ativa.Equals(1)).ToList().AsQueryable(); ;
                        
            if (pistaFiltro.nm_pista != null)
            {
                PistaEndereco = PistaEndereco
                .Where(o => o.nm_pista.ToLower().Contains(pistaFiltro.nm_pista.ToLower()))
                .Select(s => new PistaDto
                {
                    id_pista = s.id_pista,
                    id_endereco = s.id_endereco,
                    id_cidade = s.id_cidade,
                    ds_pista = s.ds_pista,
                    nm_pista = s.nm_pista,
                    ds_horario_funcionamento = s.ds_horario_funcionamento,
                    nr_latitude = s.nr_latitude,
                    nr_longitude = s.nr_longitude
                })
                ;
            }
            if (pistaFiltro.id_estado != 0 && pistaFiltro.id_cidade == 0)
            {
                PistaEndereco = PistaEndereco.Join(cidade.GetAll(),
                        p => p.id_cidade,
                        e => e.id_cidade,
                        (pist, cid) =>
                        new PistaDto
                        {
                            id_pista = pist.id_pista,
                            id_endereco = pist.id_endereco,
                            id_cidade = pist.id_cidade,
                            id_estado = cid.id_estado,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = pist.nr_latitude,
                            nr_longitude = pist.nr_longitude
                        })
                    .Where(o => o.id_estado.Equals(pistaFiltro.id_estado));
                ;
            }
            if (pistaFiltro.id_cidade != 0)
            {
                PistaEndereco = PistaEndereco
                .Where(o => o.id_cidade.Equals(pistaFiltro.id_cidade))
                .Select(s => new PistaDto
                {
                    id_pista = s.id_pista,
                    id_endereco = s.id_endereco,
                    id_cidade = s.id_cidade,
                    ds_pista = s.ds_pista,
                    nm_pista = s.nm_pista,
                    ds_horario_funcionamento = s.ds_horario_funcionamento,
                    nr_latitude = s.nr_latitude,
                    nr_longitude = s.nr_longitude
                })
                ;
            }
            if (pistaFiltro.id_modalidade != 0)
            {
                var modalidadePista = this._unitOfWork.ModalidadePistaRepository;

                PistaEndereco = PistaEndereco.Join(modalidadePista.GetAll(),
                        p => p.id_pista,
                        e => e.id_pista,
                        (pist, mod) =>
                        new PistaDto
                        {
                            id_pista = pist.id_pista,
                            id_endereco = pist.id_endereco,
                            id_cidade = pist.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = pist.nr_latitude,
                            nr_longitude = pist.nr_longitude,
                            id_modalidade = mod.id_modalidade
                        })
                    .Where(o => o.id_modalidade.Equals(pistaFiltro.id_modalidade));
                ;
            }
            if (pistaFiltro.id_nivel_dificuldade != 0)
            {
                var nivelDificuldadePista = this._unitOfWork.NiveisDificuldadePistaRepository;

                PistaEndereco = PistaEndereco.Join(nivelDificuldadePista.GetAll(),
                        p => p.id_pista,
                        e => e.id_pista,
                        (pist, niv) =>
                        new PistaDto
                        {
                            id_pista = pist.id_pista,
                            id_endereco = pist.id_endereco,
                            id_cidade = pist.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = pist.nr_latitude,
                            nr_longitude = pist.nr_longitude,
                            id_nivel_dificuldade = niv.id_nivel_dificuldade
                        })
                    .Where(o => o.id_nivel_dificuldade.Equals(pistaFiltro.id_nivel_dificuldade));
                ;
            }


            //return query.ToList();



            return PistaEndereco.ToList();
        }
        /*public IEnumerable<PistaDto> FiltrarPistas()
        {
            var pista = this._unitOfWork.PistaRepository;
            var endereco = this._unitOfWork.EnderecoRepository;
            var cidade = this._unitOfWork.CidadeRepository;

            var PistaEndereco = pista.GetAll().Join(endereco.GetAll(),
                        p => p.id_endereco,
                        e => e.id_endereco,
                        (pist, end) => 
                        new PistaDto 
                        { 
                            id_pista = pist.ID_pista,
                            id_endereco = end.id_endereco,
                            id_cidade = end.id_cidade,
                            ds_pista = pist.ds_pista,
                            nm_pista = pist.nm_pista,
                            ds_horario_funcionamento = pist.ds_horario_funcionamento,
                            nr_latitude = end.nr_latitude,
                            nr_longitude = end.nr_longitude

                        }).AsQueryable()
                .Join(cidade.GetAll(),
                        p => p.id_cidade,
                        e => e.id_cidade,
                        (pist, cid) =>
                        new PistaDto
                        {
                            id_pista = pist.id_pista,
                            id_endereco = pist.id_endereco,
                            id_estado = cid.id_estado
                        })
                .Where(o => o.id_pista.Equals(1));
                        
            
            return PistaEndereco;
        }*/
        public IEnumerable<PistaDto> FiltrarValidacao()
        {
            var query = this._unitOfWork
                .PistaRepository
                .Get(null, o => o.OrderBy(u => u.nm_pista))
                //.Join(this._unitOfWork.EnderecoRepository.Get(), pista => pista.id_endereco,endereco => endereco.id_endereco)

                .Where(o => o.id_status_aprovacao.Equals(2) || o.id_status_aprovacao.Equals(1))
                .Select(s => new PistaDto
                {
                    id_pista = s.ID_pista,
                    nm_pista = s.nm_pista,
                    //ds_pista = s.ds_pista,
                    ds_horario_funcionamento = s.ds_horario_funcionamento
                    //nr_latitude = -23.6376677026326,
                    //nr_longitude = -46.661345945319
                })
                ;
            return query.ToList();
        }

        public IEnumerable<SelectListItem> ComboTamanho()
        {
            /*
             * busca tamanho funcional com metodos normal não raw
            var query = this._unitOfWork
                .TamanhosRepository
                .Get(null, o => o.OrderBy(u => u.id_Tamanho))
                .Select(s => new SelectListItem
                {
                    Value = s.id_Tamanho,
                    Text = s.ds_tamanho
                    
                });
             

            */
            /*criar um aplication context novo (nad a ver )
            //tentativa falha de 
            var context = new ApplicationContext();
            var tamanhos = context.Tamanhos.FromSqlRaw("SELECT * FROM Tamanhos");
            return tamanhos.Select(s => new SelectListItem
            {
                Value = s.id_Tamanho,
                Text = s.ds_tamanho,
                //id_endereco = pista.id_endereco
            });
            */
            var tamanhos = _unitOfWork.TamanhosRepository.GetWithRawSql($"SELECT * FROM Tamanhos where id_Tamanho <= 3");
            

            /*
            //deletar itensssss por uma query raw 
            foreach (var item in tamanhos)
            {
                //this._unitOfWork.UsuarioRepository.Delete(item.id_Tamanho);
                this._unitOfWork.TamanhosRepository.Delete(item);
            }
            */
            /*
            //usando o single eu consigo atribuir
            var selectBox = new SelectListItem();

            selectBox.Value = tamanhos.id_Tamanho;
            selectBox.Text = tamanhos.ds_tamanho;
            */

            return tamanhos.Select(s => new SelectListItem
            {
                Value = s.id_Tamanho,
                Text = s.ds_tamanho,
                //id_endereco = pista.id_endereco
            });
        }
        
        public IEnumerable<int> BuscaPistaModalidade(int i)
        {
            var query = this._unitOfWork
                .ModalidadePistaRepository
                .Get(null, o => o.OrderBy(u => u.id_modalidade))
                .Where(o => o.id_pista.Equals(i))
                .Select(s => s.id_modalidade)
                ;
            return query;
        }
        public IEnumerable<int> BuscaPistaNiveis(int i)
        {
            var query = this._unitOfWork
                .NiveisDificuldadePistaRepository
                .Get(null, o => o.OrderBy(u => u.id_nivel_dificuldade_pista))
                .Where(o => o.id_pista.Equals(i))
                .Select(s => s.id_nivel_dificuldade)
                ;
            return query;
        }



        public PistaDto SelecionarEndereco(int id)
        {
            var endereco = this._unitOfWork
                .EnderecoRepository
                .GetById(id);

            return new PistaDto
            {
                ds_endereco = endereco.ds_endereco,
                nr_endereco = endereco.nr_endereco,
                cd_cep = endereco.cd_cep,
                nr_latitude = endereco.nr_latitude,
                nr_longitude = endereco.nr_longitude,
                id_cidade = endereco.id_cidade
                //id_endereco = pista.id_endereco
            };
        }
        public PistaDto SelecionarUsuarioEnvio(int id)
        {
            var usuario = this._unitOfWork
                .UsuarioEnvioRepository
                .GetById(id);
            if(usuario != null)
            {
                return new PistaDto
                {
                    id_usuario_envio = usuario.id_usuario_envio,
                    nm_usuario_envio = usuario.nm_usuario_envio,
                    nr_telefone = usuario.nr_telefone,
                    ds_email = usuario.ds_email
                    //id_endereco = pista.id_endereco
                };
            }
            return new PistaDto
            {
                id_usuario_envio = 0,
                nm_usuario_envio = "",
                nr_telefone = "",
                ds_email = ""
                //id_endereco = pista.id_endereco
            }; ;
        }
        public PistaDto SelecionarCidade(int id)
        {
            var cidade = this._unitOfWork
                .CidadeRepository
                .GetById(id);

            return new PistaDto
            {
                id_cidade = cidade.id_cidade,
                id_estado = cidade.id_estado
                //id_endereco = pista.id_endereco
            };
        }

        public IEnumerable<SelectListItem> ComboCidade(int idEstado)
        {
            var cidades = _unitOfWork.CidadeRepository.GetWithRawSql($"SELECT * FROM Cidade where id_estado = {idEstado}");

            return cidades.Select(s => new SelectListItem
            {
                Value = s.id_cidade,
                Text = s.nm_cidade,
                //id_endereco = pista.id_endereco
            });
        }
        public IEnumerable<SelectListItem> ComboCidade()
        {
            var cidades = _unitOfWork.CidadeRepository.GetWithRawSql($"SELECT * FROM Cidade");

            return cidades.Select(s => new SelectListItem
            {
                Value = s.id_cidade,
                Text = s.nm_cidade,
                //id_endereco = pista.id_endereco
            });
        }
        public IEnumerable<SelectListItem> ComboEstado()
        {
            var query = this._unitOfWork
                .EstadoRepository

                .Get(null, o => o.OrderBy(u => u.nm_estado))
                .Select(s => new SelectListItem
                {
                    Value = s.id_estado,
                    Text = s.nm_estado
                });
            return (query);
        }
        public IEnumerable<SelectListItem> ComboStatus()
        {
            var query = this._unitOfWork
                .StatusAprovacaoRepository

                .Get(null, o => o.OrderBy(u => u.ds_status_aprovacao))
                .Select(s => new SelectListItem
                {
                    Value = s.id_status_aprovacao,
                    Text = s.ds_status_aprovacao
                });
            return (query);
        }
        public IEnumerable<SelectListItem> ComboModalidades()
        {
            var query = this._unitOfWork
                .ModalidadesRepository

                .Get(null, o => o.OrderBy(u => u.id_modalidade))
                .Select(s => new SelectListItem
                {
                    Value = s.id_modalidade,
                    Text = s.nm_modalidade
                });
            return (query);
        }
        public IEnumerable<SelectListItem> ComboNiveis()
        {
            var query = this._unitOfWork
                .NiveisDificuldadeRepository
                .Get(null, o => o.OrderBy(u => u.id_nivel_dificuldade))
                .Select(s => new SelectListItem
                {
                    Value = s.id_nivel_dificuldade,
                    Text = s.nm_nivel_dificuldade
                });
            return (query);
        }

       
        public string[] BuscaImagens(int i)
        {
            var query = this._unitOfWork
                .FotosRepository
                .Get(null, o => o.OrderBy(u => u.id_foto))
                .Where(o => o.id_pista.Equals(i))
                .Select(s => s.nm_foto)
                ;
            return query.ToArray();
        }
        public ResultadoDto ExcluirImagem(string nm_imagem)
        {
            var query = this._unitOfWork
                .FotosRepository
                .Get(null, o => o.OrderBy(u => u.id_foto))
                .Where(o => o.nm_foto.Equals(nm_imagem))
                .Select(s => s.id_foto).Single();
           
            this._unitOfWork.FotosRepository.Delete(query);
            var sucesso = this._unitOfWork.SaveChanges();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }

        public PistaDto Selecionar(int id)
        {
            var pista = this._unitOfWork
                .PistaRepository
                .GetById(id);

            return new PistaDto
            {
                id_pista = pista.ID_pista,
                nm_pista = pista.nm_pista,
                ds_pista = pista.ds_pista,
                fl_paga = pista.fl_paga,
                fl_pista_ativa = pista.fl_pista_ativa,
                id_tamanho = pista.id_tamanho,
                id_endereco = pista.id_endereco,
                fl_capacete = pista.fl_capacete,
                fl_aluga_capacete = pista.fl_aluga_capacete,
                ds_horario_funcionamento = pista.ds_horario_funcionamento,
                nr_nota = pista.nr_nota,
                ds_notas_gerais = pista.ds_notas_gerais,
                id_status_aprovacao = pista.id_status_aprovacao,
                id_usuario_envio = pista.id_usuario_envio,
                fl_cobertura = pista.fl_cobertura

                //id_endereco = pista.id_endereco
            };
        }
        

        public ResultadoDto Excluir(int id)
        {
            var pista = Selecionar(id);

            int[] modalidadesSelecionadas = BuscaPistaModalidade(id).ToArray();
            foreach (var item in modalidadesSelecionadas)
            {
                int modalidadePista = this._unitOfWork.ModalidadePistaRepository.Get(null, o => o.OrderBy(u => u.id_modalidade_pista)).Where(o => o.id_pista.Equals(id) && o.id_modalidade.Equals(item)).Select(s => s.id_modalidade_pista).Single();
                this._unitOfWork.ModalidadePistaRepository.Delete(modalidadePista);
            }

            int[] niveisSelecionados = BuscaPistaNiveis(id).ToArray();
            foreach (var item in niveisSelecionados)
            {
                int nivelPista = this._unitOfWork.NiveisDificuldadePistaRepository.Get(null, o => o.OrderBy(u => u.id_nivel_dificuldade_pista)).Where(o => o.id_pista.Equals(id) && o.id_nivel_dificuldade.Equals(item)).Select(s => s.id_nivel_dificuldade_pista).Single();
                this._unitOfWork.NiveisDificuldadePistaRepository.Delete(nivelPista);
            }

            this._unitOfWork.PistaRepository.Delete(id);
            var sucesso = this._unitOfWork.SaveChanges();

            this._unitOfWork.EnderecoRepository.Delete(pista.id_endereco);


            sucesso = this._unitOfWork.SaveChanges();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }
        
        public ResultadoDto Salvar(PistaDto pistaDto)
        {
            var pista = new Pistas();
            var endereco = new Endereco();
            var usuario_envio = new Usuario_envio();

            var sucesso = new bool();

            if (pistaDto.id_pista > 0)
            {
                //atualiza pista
                pista = this._unitOfWork.PistaRepository.GetById(pistaDto.id_pista);
                pista.nm_pista = pistaDto.nm_pista;
                pista.ds_pista = pistaDto.ds_pista;
                pista.fl_paga = pistaDto.fl_paga;
                pista.fl_pista_ativa = pistaDto.fl_pista_ativa;
                pista.id_tamanho = pistaDto.id_tamanho;
                //pista.id_endereco = pistaDto.id_endereco;
                pista.fl_capacete = pistaDto.fl_capacete;
                pista.fl_aluga_capacete = pistaDto.fl_aluga_capacete;
                pista.ds_horario_funcionamento = pistaDto.ds_horario_funcionamento;
                pista.nr_nota = pistaDto.nr_nota;
                pista.ds_notas_gerais = pistaDto.ds_notas_gerais;
                pista.id_status_aprovacao = pistaDto.id_status_aprovacao;
                pista.fl_cobertura = pistaDto.fl_cobertura;

                this._unitOfWork.PistaRepository.Update(pista);

                //atualiza endereco
                endereco = this._unitOfWork.EnderecoRepository.GetById(pista.id_endereco);
                endereco.ds_endereco = pistaDto.ds_endereco;
                endereco.nr_endereco = pistaDto.nr_endereco;
                endereco.cd_cep = pistaDto.cd_cep;
                endereco.nr_latitude = pistaDto.nr_latitude;
                endereco.nr_longitude = pistaDto.nr_longitude;
                endereco.id_cidade = pistaDto.id_cidade;


                this._unitOfWork.EnderecoRepository.Update(endereco);

                usuario_envio = this._unitOfWork.UsuarioEnvioRepository.GetById(pista.id_usuario_envio);
                if(usuario_envio != null)
                {
                    usuario_envio.nm_usuario_envio = pistaDto.nm_usuario_envio;
                    usuario_envio.nr_telefone = pistaDto.nr_telefone;
                    usuario_envio.ds_email = pistaDto.ds_email;

                    this._unitOfWork.UsuarioEnvioRepository.Update(usuario_envio);
                }    
                


                //atualiza modalidades

                int[] modalidadesSelecionadas = this._unitOfWork.ModalidadePistaRepository.Get(null, o => o.OrderBy(u => u.id_modalidade_pista)).Where(o => o.id_pista.Equals(pistaDto.id_pista)).Select(s => s.id_modalidade).ToArray();
                int[] Adicionar = pistaDto.modalidadesSelecionadas.Except(modalidadesSelecionadas).ToArray();

                foreach (int id in Adicionar)
                {
                    var modalidadesPista = new Modalidades_Pistas();
                    modalidadesPista.id_modalidade = id;
                    modalidadesPista.id_pista = pistaDto.id_pista;
                    this._unitOfWork.ModalidadePistaRepository.Add(modalidadesPista);
                }

                //foreach adicionando os ids de modalidade que tiverem
                int[] Remover = modalidadesSelecionadas.Except(pistaDto.modalidadesSelecionadas).ToArray();

                //foreach buscando os ids de modalidade que tiverem e removendo os entitys 
                foreach (int id in Remover)
                {
                    int modalidadePista = this._unitOfWork.ModalidadePistaRepository.Get(null, o => o.OrderBy(u => u.id_modalidade_pista)).Where(o => o.id_pista.Equals(pistaDto.id_pista) && o.id_modalidade.Equals(id)).Select(s => s.id_modalidade_pista).Single();
                    this._unitOfWork.ModalidadePistaRepository.Delete(modalidadePista);

                }
                

                //atualiza niveis

                int[] niveisSelecionados = this._unitOfWork.NiveisDificuldadePistaRepository.Get(null, o => o.OrderBy(u => u.id_nivel_dificuldade_pista)).Where(o => o.id_pista.Equals(pistaDto.id_pista)).Select(s => s.id_nivel_dificuldade).ToArray();
                Adicionar = pistaDto.niveisSelecionados.Except(niveisSelecionados).ToArray();

                foreach (int id in Adicionar)
                {
                    var niveisPista = new Niveis_dificuldade_Pistas();
                    niveisPista.id_nivel_dificuldade = id;
                    niveisPista.id_pista = pistaDto.id_pista;
                    this._unitOfWork.NiveisDificuldadePistaRepository.Add(niveisPista);
                }

                //foreach adicionando os ids de modalidade que tiverem
                Remover = niveisSelecionados.Except(pistaDto.niveisSelecionados).ToArray();

                //foreach buscando os ids de modalidade que tiverem e removendo os entitys 
                foreach (int id in Remover)
                {
                    int nivelPista = this._unitOfWork.NiveisDificuldadePistaRepository.Get(null, o => o.OrderBy(u => u.id_nivel_dificuldade_pista)).Where(o => o.id_pista.Equals(pistaDto.id_pista) && o.id_nivel_dificuldade.Equals(id)).Select(s => s.id_nivel_dificuldade_pista).Single();
                    this._unitOfWork.NiveisDificuldadePistaRepository.Delete(nivelPista);
                }

                foreach (string nome in pistaDto.nm_imagens)
                {
                    var fotoPista = new Fotos();
                    fotoPista.nm_foto = nome;
                    fotoPista.id_pista = pistaDto.id_pista;
                    this._unitOfWork.FotosRepository.Add(fotoPista);
                }


            }
            else
            {            
                
                //cria pista
                //var salt = SecurityManager.CreateSalt();
                //var hash = SecurityManager.CreateHash(pistaDto.Senha, salt);
                endereco = new Endereco();
                endereco.ds_endereco = pistaDto.ds_endereco;
                endereco.nr_endereco = pistaDto.nr_endereco;
                endereco.cd_cep = pistaDto.cd_cep;
                endereco.nr_latitude = pistaDto.nr_latitude;
                endereco.nr_longitude = pistaDto.nr_longitude;
                endereco.id_cidade = pistaDto.id_cidade;

                this._unitOfWork.EnderecoRepository.Add(endereco);

                sucesso = this._unitOfWork.SaveChanges();

                int idEndereco = this._unitOfWork.EnderecoRepository.Get(null, o => o.OrderBy(u => u.ds_endereco)).Where(o => o.nr_endereco.Equals(endereco.nr_endereco) && o.cd_cep.Equals(endereco.cd_cep)).Select(s => s.id_endereco).Single();


                //antes de adicionar tem que ver se ja não existe pelo telefone
                int idUsuario;
                var buscaId = this._unitOfWork.UsuarioEnvioRepository.Get(null, o => o.OrderBy(u => u.id_usuario_envio)).Where(o => o.nr_telefone.Equals(pistaDto.nr_telefone)).Select(s => s.id_usuario_envio);
                if(buscaId.ToList().Count() == 0)
                {
                    usuario_envio = new Usuario_envio();
                    usuario_envio.nm_usuario_envio = pistaDto.nm_usuario_envio;
                    usuario_envio.nr_telefone = pistaDto.nr_telefone;
                    usuario_envio.ds_email = pistaDto.ds_email;

                    this._unitOfWork.UsuarioEnvioRepository.Add(usuario_envio);
                    sucesso = this._unitOfWork.SaveChanges();
                    idUsuario = this._unitOfWork.UsuarioEnvioRepository.Get(null, o => o.OrderBy(u => u.nm_usuario_envio)).Where(o => o.nr_telefone.Equals(usuario_envio.nr_telefone)).Select(s => s.id_usuario_envio).Single();

                }
                else
                {
                    idUsuario = buscaId.Single();
                }

                pista = new Pistas();
                //atualiza pista
                pista.nm_pista = pistaDto.nm_pista;
                pista.ds_pista = pistaDto.ds_pista;
                pista.fl_paga = pistaDto.fl_paga;
                pista.fl_pista_ativa = 0;
                pista.id_tamanho = pistaDto.id_tamanho;
                pista.id_endereco = idEndereco;
                pista.fl_capacete = pistaDto.fl_capacete;
                pista.fl_aluga_capacete = pistaDto.fl_aluga_capacete;
                pista.ds_horario_funcionamento = pistaDto.ds_horario_funcionamento;
                pista.nr_nota = pistaDto.nr_nota;
                pista.ds_notas_gerais = pistaDto.ds_notas_gerais;
                pista.id_status_aprovacao = 2;
                pista.id_usuario_envio = idUsuario;
                pista.fl_cobertura = pistaDto.fl_cobertura;

                this._unitOfWork.PistaRepository.Add(pista);

                sucesso = this._unitOfWork.SaveChanges();

                int idPista = this._unitOfWork.PistaRepository.Get(null, o => o.OrderBy(u => u.nm_pista)).Where(o => o.id_endereco.Equals(pista.id_endereco) && o.ds_pista.Equals(pista.ds_pista)).Select(s => s.ID_pista).Single();

                foreach (int id in pistaDto.modalidadesSelecionadas)
                {
                    var modalidadesPista = new Modalidades_Pistas();
                    modalidadesPista.id_modalidade = id;
                    modalidadesPista.id_pista = idPista;
                    this._unitOfWork.ModalidadePistaRepository.Add(modalidadesPista);
                }

                foreach (int id in pistaDto.niveisSelecionados)
                {
                    var niveisPista = new Niveis_dificuldade_Pistas();
                    niveisPista.id_nivel_dificuldade = id;
                    niveisPista.id_pista = idPista;
                    this._unitOfWork.NiveisDificuldadePistaRepository.Add(niveisPista);
                }

                foreach (string nome in pistaDto.nm_imagens)
                {
                    var fotoPista = new Fotos();
                    fotoPista.nm_foto = nome;
                    fotoPista.id_pista = idPista;
                    this._unitOfWork.FotosRepository.Add(fotoPista);
                }

            }

            sucesso = this._unitOfWork.SaveChanges();
            var resultado = new ResultadoDto
            {
                Sucesso = sucesso,
                Id = pista.ID_pista
            };
            
            return resultado;
        }
        public virtual PistaDto VerificaNome(string Nome, int id)
        {
            var pista = this._unitOfWork
                .PistaRepository
                .Get(q => q.nm_pista.ToLower().Equals(Nome) && q.ID_pista != id)
                .FirstOrDefault();

            //if (!SecurityManager.Validate(loginDto.Senha, usuario.Salt, usuario.Hash))
            //return null;

            if (pista == null)
            {
                return null;
            }
            else
            {
                return new PistaDto
                {
                    id_pista = pista.ID_pista

                };
            }

        }

    }
}
