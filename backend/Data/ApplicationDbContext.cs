using Microsoft.EntityFrameworkCore;
using MyUniversityAPP.Models;




namespace MyUniversityAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define o esquema padrão para todas as tabelas neste DbContext
            modelBuilder.HasDefaultSchema("MyUniversity");
            //modelBuilder.HasAnnotation("Relational:Schema", "MyUniversity");

            // Configurações adicionais específicas de tabelas
            modelBuilder.Entity<Aluno>().ToTable("Alunos");
            modelBuilder.Entity<Matricula>().ToTable("Matriculas");
            modelBuilder.Entity<Curso>().ToTable("Cursos");
            modelBuilder.Entity<Professor>().ToTable("Professores");
            modelBuilder.Entity<Disciplina>().ToTable("Disciplinas");
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");

            // Configurações adicionais

            modelBuilder.HasDefaultSchema("MyUniversity");

            // Configuração para a propriedade Nota em Matricula
            modelBuilder.Entity<Matricula>()
                .Property(m => m.Nota)
                .HasPrecision(18, 2);

            // Configuração para a propriedade Salario em Professor
            modelBuilder.Entity<Professor>()
                .Property(p => p.Salario)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

        public DbSet<Usuario> Usuario{ get; set; }

    }
}
