using System;
using System.Collections.Generic;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
    public interface IPistaBusiness
    {
        IEnumerable<PistaDto> Filtrar();
        PistaDto Selecionar(int id);
        IEnumerable<SelectListItem> BuscaTamanho();

        ResultadoDto Excluir(int id);
        //ResultadoDto Salvar(PistaDto Pista);
    }
}
