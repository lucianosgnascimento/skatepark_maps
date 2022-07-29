using System;
using System.Collections.Generic;
using ProjetoPista.Model.Dtos;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
    public interface IPistaBusiness
    {
        IEnumerable<PistaDto> Filtrar();
        IEnumerable<PistaDto> FiltrarValidacao();
        IEnumerable<PistaDto> FiltrarPistas(); 
        IEnumerable<PistaDto> FiltrarPistasPerto(double lat,double lon);
        IEnumerable<PistaDto> FiltrarPistas(PistaFiltroDto pistaFiltro);
        PistaDto Selecionar(int id);
        IEnumerable<SelectListItem> ComboTamanho();
        PistaDto SelecionarCidade(int id);
        IEnumerable<SelectListItem> ComboCidade(int idEstado); 
        IEnumerable<SelectListItem> ComboCidade();
        IEnumerable<SelectListItem> ComboEstado();
        IEnumerable<SelectListItem> ComboStatus();
        IEnumerable<SelectListItem> ComboModalidades();
        IEnumerable<int> BuscaPistaModalidade(int i);
        PistaDto SelecionarUsuarioEnvio(int id);
        IEnumerable<int> BuscaPistaNiveis(int i);
        IEnumerable<SelectListItem> ComboNiveis();
        string[] BuscaImagens(int i);
        ResultadoDto ExcluirImagem(string nm_imagem);
        PistaDto SelecionarEndereco(int id);

        PistaDto VerificaNome(string Nome,int id);

        ResultadoDto Excluir(int id);
        ResultadoDto Salvar(PistaDto Pista);
    }
}
