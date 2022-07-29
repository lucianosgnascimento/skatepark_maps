using System;
using ProjetoPista.Data.Repositories;
using ProjetoPista.Model.Interfaces;

namespace ProjetoPista.Data
{
	public class UnitOfWork : IUnitOfWork
    {
		public ApplicationContext Context { get; internal set; }

		private IUsuarioRepository usuarioRepository;

		private IPistaRepository pistaRepository; 

		private ITamanhosRepository tamanhosRepository;

		private IOtherRepository otherRepository;

		public UnitOfWork(ApplicationContext context)
        {
			this.Context = context;
        }

		public IUsuarioRepository UsuarioRepository
		{
			get
			{
				if (this.usuarioRepository == null)
					this.usuarioRepository = new UsuarioRepository(this.Context);
				return this.usuarioRepository;
			}
		}

		public IPistaRepository PistaRepository
		{
			get
			{
				if (this.pistaRepository == null)
					this.pistaRepository = new PistaRepository(this.Context);
				return this.pistaRepository;
			}
		}

		public ITamanhosRepository TamanhosRepository
		{
			get
			{
				if (this.tamanhosRepository == null)
					this.tamanhosRepository = new TamanhosRepository(this.Context);
				return this.tamanhosRepository;
			}
			

		}
		public IOtherRepository OtherRepository
		{
			get
			{
				if (this.otherRepository == null)
					this.otherRepository = new OtherRepository(this.Context);
				return this.otherRepository;
			}
		}

		public bool SaveChanges()
		{
			return this.Context.SaveChanges() > 0;
		}
    }
}
