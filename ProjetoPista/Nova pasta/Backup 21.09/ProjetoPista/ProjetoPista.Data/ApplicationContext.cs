using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using ProjetoPista.Data.Mapping;
using ProjetoPista.Model.Entities;
#nullable disable

namespace ProjetoPista.Data

{
    public partial class ApplicationContext : DbContext
    {

        

        public ApplicationContext()
        {
        }

        private readonly ILogger<ApplicationContext> _logger;

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Pistas> Pistas { get; set; }

        public DbSet<Tamanhos> Tamanhos { get; set; }

        public DbSet<Professores> Professores { get; set; }
        public DbSet<Pistas_Professores> Pistas_Professores { get; set; }
        public DbSet<Modalidades> Modalidades { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<Status_aprovacao> Status_aprovacao { get; set; }
        public DbSet<Niveis_dificuldade> Niveis_dificuldade { get; set; }
        public DbSet<Niveis_dificuldade_Pistas> Niveis_dificuldade_Pistas { get; set; }
        public DbSet<Modalidades_Pistas> Modalidades_Pistas { get; set; }
        public DbSet<Fotos> Fotos { get; set; }


        public ApplicationContext(DbContextOptions<ApplicationContext> options, ILogger<ApplicationContext> logger)
            : base(options)
        {
            _logger = logger;
        }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-QJIOM3MT;Database=BasePistas;Trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _logger.Log(LogLevel.Information, "OnModelCreating...");
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new PistaConfig());
            modelBuilder.ApplyConfiguration(new TamanhosConfig());
            modelBuilder.ApplyConfiguration(new ProfessoresConfig());
            modelBuilder.ApplyConfiguration(new PistaProfessorConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());
            modelBuilder.ApplyConfiguration(new TamanhosConfig());
            modelBuilder.ApplyConfiguration(new ModalidadesConfig());
            modelBuilder.ApplyConfiguration(new CidadeConfig());
            modelBuilder.ApplyConfiguration(new EstadoConfig());
            modelBuilder.ApplyConfiguration(new EnderecoConfig());
            modelBuilder.ApplyConfiguration(new StatusAprovacaoConfig());
            modelBuilder.ApplyConfiguration(new NiveisDificuldadeConfig());
            modelBuilder.ApplyConfiguration(new NiveisDificuldadePistaConfig());
            modelBuilder.ApplyConfiguration(new ModalidadePistaConfig());
            modelBuilder.ApplyConfiguration(new FotosConfig());


            //modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            //OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
