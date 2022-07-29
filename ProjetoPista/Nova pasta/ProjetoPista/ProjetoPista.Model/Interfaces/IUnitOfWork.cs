using System;
namespace ProjetoPista.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }

        IPistaRepository PistaRepository { get; }

        ITamanhosRepository TamanhosRepository { get; }

        IOtherRepository OtherRepository { get; }

        bool SaveChanges();
    }
}
