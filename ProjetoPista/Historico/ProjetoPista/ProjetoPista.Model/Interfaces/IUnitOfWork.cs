using System;
namespace ProjetoPista.Model.Interfaces
{
    public interface IUnitOfWork
    {
		IUsuarioRepository UsuarioRepository { get; }

		bool SaveChanges();
    }
}
