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
    public class PistaBusiness : IPistaBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        



        public PistaBusiness(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
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
                    id_endereco = s.id_endereco
                });
            return query.ToList();
        }

        public IEnumerable<SelectListItem> BuscaTamanho()
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
            int id = 3;
            var tamanhos = _unitOfWork.TamanhosRepository.GetWithRawSql($"SELECT * FROM Tamanhos where id_Tamanho <= {id}");
            

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
                id_tamanho = pista.id_tamanho
                //id_endereco = pista.id_endereco
            };
        }
        

        public ResultadoDto Excluir(int id)
        {
            this._unitOfWork.UsuarioRepository.Delete(id);
            var sucesso = this._unitOfWork.SaveChanges();
            return new ResultadoDto
            {
                Sucesso = sucesso
            };
        }
        /*
        public ResultadoDto Salvar(PistaDto pistaDto)
        {
            var pista = new Pista();

            if (pistaDto.Id_pista > 0)
            {
                pista = this._unitOfWork.PistaRepository.GetById(pistaDto.Id_pista);
                pista.Nome = pistaDto.Nome;
                pista.Email = pistaDto.Email;

                this._unitOfWork.PistaRepository.Update(pista);
            }
            else
            {                
                var salt = SecurityManager.CreateSalt();
                var hash = SecurityManager.CreateHash(pistaDto.Senha, salt);

                pista = new Pista();
                pista.Nome = pistaDto.Nome;
                pista.Email = pistaDto.Email;
                pista.Login = pistaDto.Login;
                pista.Hash = hash;
                pista.Salt = salt;
                this._unitOfWork.PistaRepository.Add(pista);
            }

            var sucesso = this._unitOfWork.SaveChanges();
            var resultado = new ResultadoDto
            {
                Sucesso = sucesso,
                Id = pista.id_pista
            };
            
            return resultado;
        }*/
        
    }
}
