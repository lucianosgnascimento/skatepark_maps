using System;
using System.Collections.Generic;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
    public interface IProfessorBusiness
    {
        IEnumerable<ProfessorDto> Filtrar();
        IEnumerable<ProfessorDto> BuscaProfessorFiltrado(ProfessorFiltroDto professores);
        ProfessorDto SelecionarProfessor(int id);
        IEnumerable<SelectListItem> ComboPistas();
        IEnumerable<int> BuscaPistaProfessor(int i);
        string VerificaProf(ProfessorDto professorDto);
        //IEnumerable<SelectListItem> ComboTamanho();
        //ProfessorDto SelecionarCidade(int id);
        //IEnumerable<SelectListItem> ComboCidade(int idEstado); 
        //IEnumerable<SelectListItem> ComboCidade();
        //IEnumerable<SelectListItem> ComboEstado();
        IEnumerable<SelectListItem> ComboStatus();
        //IEnumerable<SelectListItem> ComboModalidades();
        //IEnumerable<int> BuscaPistaModalidade(int i);
        //IEnumerable<int> BuscaPistaNiveis(int i);
        //IEnumerable<SelectListItem> ComboNiveis();

        //ProfessorDto SelecionarEndereco(int id);
        

        /*
        ResultadoDto Excluir(int id);
        */
        ResultadoDto Salvar(ProfessorDto Pista);
        
    }
}
