using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Data;
using ProjetoPista.Utils;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace ProjetoPista.Business
{
    public class ProfessorBusiness : IProfessorBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        



        public ProfessorBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        

        public IEnumerable<ProfessorDto> Filtrar()
        {
            var query = this._unitOfWork
                .ProfessoresRepository
                .Get(null, o => o.OrderBy(u => u.nm_professor))
                .Select(s => new ProfessorDto
                {
                    id_professor = s.id_professor,
                    nm_professor = s.nm_professor,
                    nm_apelido = s.nm_apelido,
                    nm_profile = s.nm_profile,
                    cd_cpf = s.cd_cpf,
                    ds_instagram = s.ds_instagram,
                    ds_telefone = s.ds_telefone,
                    ds_email = s.ds_email,
                    nr_estrelas = s.nr_estrelas,
                    nr_anos_experiencia = s.nr_anos_experiencia,
                    fl_ativo = s.fl_ativo,
                    vl_hora_aula = s.vl_hora_aula,
                    id_status_aprovacao = s.id_status_aprovacao
                })
                ;
            return query.ToList();
        }

        public IEnumerable<ProfessorDto> BuscaProfessorFiltrado(ProfessorFiltroDto professores)
        {

            var query = this._unitOfWork
                .ProfessoresRepository
                .Get(null, o => o.OrderBy(u => u.nm_professor))
                .Where(o => o.fl_ativo.Equals(1))
                .Select(s => new ProfessorDto
                {
                    id_professor = s.id_professor,
                    nm_professor = s.nm_professor,
                    nm_apelido = s.nm_apelido,
                    nm_profile = s.nm_profile,
                })
                ;
            if (professores.nm_professor != null)
            {
                query = query
                .Where(o => o.nm_professor.Contains(professores.nm_professor))
                .Select(s => new ProfessorDto
                {
                    id_professor = s.id_professor,
                    nm_professor = s.nm_professor,
                    nm_apelido = s.nm_apelido,
                    nm_profile = s.nm_profile,
                })
                ;
            }
            if (professores.nm_apelido != null)
            {
                query = query
                .Where(o => o.nm_apelido.Contains(professores.nm_apelido))
                .Select(s => new ProfessorDto
                {
                    id_professor = s.id_professor,
                    nm_professor = s.nm_professor,
                    nm_apelido = s.nm_apelido,
                    nm_profile = s.nm_profile,
                })
                ;
            }

            return query.ToList();
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
        public virtual string VerificaProf(ProfessorDto professorDto)
        {
            string texto = null;
            if(professorDto.cd_cpf != null)
            {
                var cpf = this._unitOfWork
                .ProfessoresRepository
                .Get(q => q.cd_cpf.ToLower().Equals(professorDto.cd_cpf) && q.id_professor != professorDto.id_professor)
                .FirstOrDefault();

                texto = cpf == null ? "true" : "O cpf já foi cadastrado";
            }
            if (professorDto.ds_telefone != null)
            {
                var cpf = this._unitOfWork
                .ProfessoresRepository
                .Get(q => q.ds_telefone.ToLower().Equals(professorDto.ds_telefone) && q.id_professor != professorDto.id_professor)
                .FirstOrDefault();

                texto = cpf == null ? "true" : "O telefone já foi cadastrado";
            }
            if (professorDto.nm_apelido != null)
            {
                var cpf = this._unitOfWork
                .ProfessoresRepository
                .Get(q => q.nm_apelido.ToLower().Equals(professorDto.nm_apelido) && q.id_professor != professorDto.id_professor)
                .FirstOrDefault();

                texto = cpf == null ? "true" : "O Apelido já foi cadastrado";
            }
            if (professorDto.ds_email != null)
            {
                var cpf = this._unitOfWork
                .ProfessoresRepository
                .Get(q => q.ds_email.ToLower().Equals(professorDto.ds_email) && q.id_professor != professorDto.id_professor)
                .FirstOrDefault();

                texto = cpf == null ? "true" : "O email já foi cadastrado";
            }

            //if (!SecurityManager.Validate(loginDto.Senha, usuario.Salt, usuario.Hash))
            //return null;


            return texto;
            

        }
        /*
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
        }*/
        public IEnumerable<SelectListItem> ComboPistas()
        {
            var query = this._unitOfWork
                .PistaRepository
                .Get(null, o => o.OrderBy(u => u.ID_pista))
                .Select(s => new SelectListItem
                {
                    Value = s.ID_pista,
                    Text = s.nm_pista
                });
            return (query);
        }
        public IEnumerable<int> BuscaPistaProfessor(int i)
        {
            var query = this._unitOfWork
                .PistaProfessorRepository
                .Get(null, o => o.OrderBy(u => u.id_pista_professor))
                .Where(o => o.id_professor.Equals(i))
                .Select(s => s.id_pista)
                ;
            return query;
        }
        public ProfessorDto SelecionarProfessor(int id)
        {
            var professor = this._unitOfWork
                .ProfessoresRepository
                .GetById(id);

            return new ProfessorDto
            {
                id_professor = professor.id_professor,
                nm_professor = professor.nm_professor,
                cd_cpf = professor.cd_cpf,
                ds_instagram = professor.ds_instagram,
                ds_telefone = professor.ds_telefone,
                ds_email = professor.ds_email,
                nm_apelido = professor.nm_apelido,
                nr_estrelas = professor.nr_estrelas,
                nr_anos_experiencia = professor.nr_anos_experiencia,
                fl_ativo = professor.fl_ativo,
                vl_hora_aula = professor.vl_hora_aula,
                id_status_aprovacao = professor.id_status_aprovacao,
                nm_profile = professor.nm_profile
            };
        }

        public ProfessorDto SelecionarProfessorFull(int id)
        {
            var professor = this._unitOfWork
                .ProfessoresRepository
                .GetById(id);

            var pistaProf = this._unitOfWork.PistaProfessorRepository;
            var pista = this._unitOfWork.PistaRepository;


            return new ProfessorDto
            {
                id_professor = professor.id_professor,
                nm_professor = professor.nm_professor,
                cd_cpf = professor.cd_cpf,
                ds_instagram = professor.ds_instagram,
                ds_telefone = professor.ds_telefone,
                ds_email = professor.ds_email,
                nm_apelido = professor.nm_apelido,
                nr_estrelas = professor.nr_estrelas,
                nr_anos_experiencia = professor.nr_anos_experiencia,
                fl_ativo = professor.fl_ativo,
                vl_hora_aula = professor.vl_hora_aula,
                id_status_aprovacao = professor.id_status_aprovacao,
                nm_profile = professor.nm_profile
            };
        }
        

        public IEnumerable<PistaDto> FiltrarPistasProf(int id)
        {
            var Professorpista = this._unitOfWork.PistaProfessorRepository.Get(null, o => o.OrderBy(u => u.id_pista_professor)).Where(o => o.id_professor.Equals(id)).Select(s => s.id_pista).ToList();


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
                            id_status_aprovacao = pist.id_status_aprovacao,
                            modalidadesSelecionadas = this._unitOfWork.ModalidadePistaRepository.Get(null, o => o.OrderBy(u => u.id_modalidade_pista)).Where(o => o.id_pista.Equals(pist.ID_pista)).Select(s => s.id_modalidade).ToArray()


                        })
                        .Where(o => o.id_status_aprovacao.Equals(1) && Professorpista.Contains(o.id_pista))
                ;

            return PistaEndereco.ToList();
        }

        public ResultadoDto Excluir(int id)
        {
            this._unitOfWork.ProfessoresRepository.Delete(id);
            var sucesso = this._unitOfWork.SaveChanges();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }
      
        public ResultadoDto Salvar(ProfessorDto professorDto)
        {
            var professor = new Professores();
            var sucesso = new bool();
            if (professorDto.id_professor > 0)
            {
                //atualiza professor
                //atualiza professor
                professor = this._unitOfWork.ProfessoresRepository.GetById(professorDto.id_professor);
                professor.nm_professor = professorDto.nm_professor;
                professor.cd_cpf = professorDto.cd_cpf;
                professor.ds_telefone = professorDto.ds_telefone;
                professor.ds_email = professorDto.ds_email;
                professor.ds_instagram = professorDto.ds_instagram;
                professor.nr_estrelas = professorDto.nr_estrelas;
                professor.nr_anos_experiencia = professorDto.nr_anos_experiencia;
                professor.nm_apelido = professorDto.nm_apelido;
                professor.vl_hora_aula = professorDto.vl_hora_aula;
                professor.fl_ativo = professorDto.fl_ativo;
                professor.id_status_aprovacao = professorDto.id_status_aprovacao;
                if(professorDto.nm_profile != null)
                {
                    professor.nm_profile = professorDto.nm_profile;
                }
                else
                {
                    professor.nm_profile = professor.nm_profile;
                }


                this._unitOfWork.ProfessoresRepository.Update(professor);
                //atualiza pistas

                int[] ids_pistas_professor = this._unitOfWork.PistaProfessorRepository.Get(null, o => o.OrderBy(u => u.id_pista_professor)).Where(o => o.id_pista.Equals(professorDto.id_professor)).Select(s => s.id_pista).ToArray();
                int[] Adicionar = professorDto.ids_pistas_professor.Except(ids_pistas_professor).ToArray();

                foreach (int id in Adicionar)
                {
                    var pistasProfessores = new Pistas_Professores();
                    pistasProfessores.id_pista = id;
                    pistasProfessores.id_professor = professorDto.id_professor;
                    this._unitOfWork.PistaProfessorRepository.Add(pistasProfessores);
                }

                //foreach adicionando os ids de pistas que tiverem
                int[] Remover = ids_pistas_professor.Except(professorDto.ids_pistas_professor).ToArray();

                //foreach buscando os ids de pistas que tiverem e removendo os entitys 
                foreach (int id in Remover)
                {
                    int pistasProfessores = this._unitOfWork.PistaProfessorRepository.Get(null, o => o.OrderBy(u => u.id_pista_professor)).Where(o => o.id_professor.Equals(professorDto.id_professor) && o.id_pista.Equals(id)).Select(s => s.id_pista_professor).Single();
                    this._unitOfWork.PistaProfessorRepository.Delete(pistasProfessores);

                }
            }
            else
            {

                //cria professor
                //var salt = SecurityManager.CreateSalt();
                //var hash = SecurityManager.CreateHash(pistaDto.Senha, salt);
                professor = new Professores();
                professor.nm_professor = professorDto.nm_professor;
                professor.cd_cpf = professorDto.cd_cpf;
                professor.ds_telefone = professorDto.ds_telefone;
                professor.ds_email = professorDto.ds_email;
                professor.ds_instagram = professorDto.ds_instagram;
                professor.nr_estrelas = professorDto.nr_estrelas;
                professor.nr_anos_experiencia = professorDto.nr_anos_experiencia;
                professor.nm_apelido = professorDto.nm_apelido;
                professor.vl_hora_aula = professorDto.vl_hora_aula;
                professor.fl_ativo = professorDto.fl_ativo;
                professor.id_status_aprovacao = 2;
                professor.nm_profile = professorDto.nm_profile;


                this._unitOfWork.ProfessoresRepository.Add(professor);
                sucesso = this._unitOfWork.SaveChanges();

                //var sucesso = this._unitOfWork.SaveChanges();

                int idProfessor = this._unitOfWork.ProfessoresRepository.Get(null, o => o.OrderBy(u => u.id_professor)).Where(o => o.cd_cpf.Equals(professor.cd_cpf) ).Select(s => s.id_professor).Single();

                foreach (int id in professorDto.ids_pistas_professor)
                {
                    var pistaProfessor = new Pistas_Professores();
                    pistaProfessor.id_professor = idProfessor;
                    pistaProfessor.id_pista = id;
                    this._unitOfWork.PistaProfessorRepository.Add(pistaProfessor);
                }


            }

            sucesso = this._unitOfWork.SaveChanges();
            var resultado = new ResultadoDto
            {
                Sucesso = sucesso,
                Id = professor.id_professor
            };
            
            return resultado;
        }
        
    }
}
