using System;
using ProjetoPista.Model.Entities;

namespace ProjetoPista.Model.Interfaces
{
	public interface IPistaRepository : IGenericRepository<Pistas> { }
    public interface ITamanhosRepository : IGenericRepository<Tamanhos> { }
    public interface IModalidadesRepository : IGenericRepository<Modalidades> { }
    public interface ICidadeRepository : IGenericRepository<Cidade> { }
    public interface IEstadoRepository : IGenericRepository<Estado> { }
    public interface IEnderecoRepository : IGenericRepository<Endereco> { }
    public interface IStatusAprovacaoRepository : IGenericRepository<Status_aprovacao> { }
    public interface INiveisDificuldadeRepository : IGenericRepository<Niveis_dificuldade> { }
    public interface INiveisDificuldadePistaRepository : IGenericRepository<Niveis_dificuldade_Pistas> { }
    public interface IModalidadePistaRepository : IGenericRepository<Modalidades_Pistas> { }
    public interface IFotosRepository : IGenericRepository<Fotos> { }

}
