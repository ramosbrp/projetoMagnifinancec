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

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Professor> Professors { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }

    }
}
