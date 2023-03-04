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

		private IProfessoresRepository professoresRepository;

		private IPistaProfessorRepository pistaProfessorRepository;

		private IModalidadesRepository modalidadesRepository;
		private ICidadeRepository cidadeRepository;
		private IEstadoRepository estadoRepository;
		private IEnderecoRepository enderecoRepository;
		private IStatusAprovacaoRepository statusAprovacaoRepository;
		private INiveisDificuldadeRepository niveisDificuldadeRepository;
		private INiveisDificuldadePistaRepository niveisDificuldadePistaRepository;
		private IModalidadePistaRepository modalidadePistaRepository;
		private IFotosRepository fotosRepository;
		private IUsuarioEnvioRepository usuarioEnvioRepository;



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

		public ICidadeRepository CidadeRepository
		{
			get
			{
				if (this.cidadeRepository == null)
					this.cidadeRepository = new CidadeRepository(this.Context);
				return this.cidadeRepository;
			}


		}

		public IEstadoRepository EstadoRepository
		{
			get
			{
				if (this.estadoRepository == null)
					this.estadoRepository = new EstadoRepository(this.Context);
				return this.estadoRepository;
			}


		}
		public IModalidadesRepository ModalidadesRepository
		{
			get
			{
				if (this.modalidadesRepository == null)
					this.modalidadesRepository = new ModalidadesRepository(this.Context);
				return this.modalidadesRepository;
			}
		}
		public IEnderecoRepository EnderecoRepository
		{
			get
			{
				if (this.enderecoRepository == null)
					this.enderecoRepository = new EnderecoRepository(this.Context);
				return this.enderecoRepository;
			}


		}
		public IStatusAprovacaoRepository StatusAprovacaoRepository
		{
			get
			{
				if (this.statusAprovacaoRepository == null)
					this.statusAprovacaoRepository = new StatusAprovacaoRepository(this.Context);
				return this.statusAprovacaoRepository;
			}


		}
		public INiveisDificuldadeRepository NiveisDificuldadeRepository
		{
			get
			{
				if (this.niveisDificuldadeRepository == null)
					this.niveisDificuldadeRepository = new NiveisDificuldadeRepository(this.Context);
				return this.niveisDificuldadeRepository;
			}


		}
		public INiveisDificuldadePistaRepository NiveisDificuldadePistaRepository
		{
			get
			{
				if (this.niveisDificuldadePistaRepository == null)
					this.niveisDificuldadePistaRepository = new NiveisDificuldadePistaRepository(this.Context);
				return this.niveisDificuldadePistaRepository;
			}
		}
		public IModalidadePistaRepository ModalidadePistaRepository
		{
			get
			{
				if (this.modalidadePistaRepository == null)
					this.modalidadePistaRepository = new ModalidadePistaRepository(this.Context);
				return this.modalidadePistaRepository;
			}


		}
		public IFotosRepository FotosRepository
		{
			get
			{
				if (this.fotosRepository == null)
					this.fotosRepository = new FotosRepository(this.Context);
				return this.fotosRepository;
			}


		}

		public IProfessoresRepository ProfessoresRepository
		{
			get
			{
				if (this.professoresRepository == null)
					this.professoresRepository = new ProfessoresRepository(this.Context);
				return this.professoresRepository;
			}


		}

		public IPistaProfessorRepository PistaProfessorRepository
		{
			get
			{
				if (this.pistaProfessorRepository == null)
					this.pistaProfessorRepository = new PistaProfessorRepository(this.Context);
				return this.pistaProfessorRepository;
			}


		}
		public IUsuarioEnvioRepository UsuarioEnvioRepository
		{
			get
			{
				if (this.usuarioEnvioRepository == null)
					this.usuarioEnvioRepository = new UsuarioEnvioRepository(this.Context);
				return this.usuarioEnvioRepository;
			}


		}

		public bool SaveChanges()
		{
			return this.Context.SaveChanges() > 0;
		}
    }
}
