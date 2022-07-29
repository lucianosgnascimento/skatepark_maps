using System;
namespace ProjetoPista.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }

        IPistaRepository PistaRepository { get; }

        ITamanhosRepository TamanhosRepository { get; }
        IModalidadesRepository ModalidadesRepository { get; }
        ICidadeRepository CidadeRepository { get; }
        IEstadoRepository EstadoRepository { get; }
        IEnderecoRepository EnderecoRepository { get; }
        IStatusAprovacaoRepository StatusAprovacaoRepository { get; }
        INiveisDificuldadeRepository NiveisDificuldadeRepository { get; }
        INiveisDificuldadePistaRepository NiveisDificuldadePistaRepository { get; }
        IModalidadePistaRepository ModalidadePistaRepository { get; }
        IFotosRepository FotosRepository { get; }
        IProfessoresRepository ProfessoresRepository { get; }
        IPistaProfessorRepository PistaProfessorRepository { get; }

        bool SaveChanges();
    }
}
