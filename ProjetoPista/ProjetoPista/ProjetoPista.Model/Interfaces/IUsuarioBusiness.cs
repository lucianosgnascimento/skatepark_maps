using System;
using System.Collections.Generic;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
    public interface IUsuarioBusiness
    {
        UsuarioDto Autenticar(LoginDto loginDto);
        IEnumerable<UsuarioDto> Filtrar();
        UsuarioDto Selecionar(int id);
        ResultadoDto Excluir(int id);
        ResultadoDto Salvar(UsuarioDto usuario);
        UsuarioDto VerificaEmail(string Email);
        UsuarioDto VerificaLogin(string Login);
    }
}
