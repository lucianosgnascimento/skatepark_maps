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
        //public IEnumerable<SelectListItem> ComboTamanho()
        //{
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
        //var tamanhos = _unitOfWork.TamanhosRepository.GetWithRawSql($"SELECT * FROM Tamanhos where id_Tamanho <= 3");


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
        /*
        return tamanhos.Select(s => new SelectListItem
        {
            Value = s.id_Tamanho,
            Text = s.ds_tamanho,
            //id_endereco = pista.id_endereco
        });
    }
    */
        /*public IEnumerable<int> BuscaPistaModalidade(int i)
        {
            var query = this._unitOfWork
                .ModalidadePistaRepository
                .Get(null, o => o.OrderBy(u => u.id_modalidade))
                .Where(o => o.id_pista.Equals(i))
                .Select(s => s.id_modalidade)
                ;
            return query;
        }
        



        public ProfessorDto SelecionarEndereco(int id)
        {
            var endereco = this._unitOfWork
                .EnderecoRepository
                .GetById(id);

            return new ProfessorDto
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

        public ProfessorDto SelecionarCidade(int id)
        {
            var cidade = this._unitOfWork
                .CidadeRepository
                .GetById(id);

            return new ProfessorDto
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
        */
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
