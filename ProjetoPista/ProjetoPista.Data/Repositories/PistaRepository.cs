using System;
using ProjetoPista.Model.Entities;
using ProjetoPista.Model.Interfaces;
using System.Collections.Generic;
using System.Linq;
using ProjetoPista.Model.Dtos;

namespace ProjetoPista.Data.Repositories
{
    public class PistaRepository : GenericRepository<Pistas>, IPistaRepository
    {
        public PistaRepository(ApplicationContext context)
            : base(context)
        {
        }

    }
    public class TamanhosRepository : GenericRepository<Tamanhos>, ITamanhosRepository
    {
        public TamanhosRepository(ApplicationContext context)
            : base(context)
        {
        }


    }

    public class ModalidadesRepository : GenericRepository<Modalidades>, IModalidadesRepository
    {
        public ModalidadesRepository(ApplicationContext context)
            : base(context)
        {
        }


    }

    public class CidadeRepository : GenericRepository<Cidade>, ICidadeRepository
    {
        public CidadeRepository(ApplicationContext context)
            : base(context)
        {
        }


    }
    public class EstadoRepository : GenericRepository<Estado>, IEstadoRepository
    {
        public EstadoRepository(ApplicationContext context)
            : base(context)
        {
        }


    }

    public class EnderecoRepository : GenericRepository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ApplicationContext context)
            : base(context)
        {
        }


    }

    public class StatusAprovacaoRepository : GenericRepository<Status_aprovacao>, IStatusAprovacaoRepository
    {
        public StatusAprovacaoRepository(ApplicationContext context)
            : base(context)
        {
        }


    }
    public class NiveisDificuldadeRepository : GenericRepository<Niveis_dificuldade>, INiveisDificuldadeRepository
    {
        public NiveisDificuldadeRepository(ApplicationContext context)
            : base(context)
        {
        }


    }

    public class NiveisDificuldadePistaRepository : GenericRepository<Niveis_dificuldade_Pistas>, INiveisDificuldadePistaRepository
    {
        public NiveisDificuldadePistaRepository(ApplicationContext context)
            : base(context)
        {
        }
    }
    public class ModalidadePistaRepository : GenericRepository<Modalidades_Pistas>, IModalidadePistaRepository
    {
        public ModalidadePistaRepository(ApplicationContext context)
            : base(context)
        {
        }


    }
    public class FotosRepository : GenericRepository<Fotos>, IFotosRepository
    {
        public FotosRepository(ApplicationContext context)
            : base(context)
        {
        }


    }
    public class UsuarioEnvioRepository : GenericRepository<Usuario_envio>, IUsuarioEnvioRepository
    {
        public UsuarioEnvioRepository(ApplicationContext context)
            : base(context)
        {
        }


    }
}
