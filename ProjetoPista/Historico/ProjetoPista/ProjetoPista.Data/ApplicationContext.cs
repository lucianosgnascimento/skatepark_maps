using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Logging;
using ProjetoPista.Data.Mapping;
using ProjetoPista.Model.Entities;
#nullable disable

namespace ProjetoPista.Data.ApplicationContext

{
    public partial class ApplicationContext : DbContext
    {

        

        public ApplicationContext()
        {
        }

        private readonly ILogger<ApplicationContext> _logger;

        public DbSet<Usuario> Usuarios { get; set; }

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
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
