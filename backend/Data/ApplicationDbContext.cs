using MyUniversityAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet <Aluno> Alunos { get; set; }
        public DbSet <Matricula> Matriculas { get; set; }
        public DbSet <Curso> Cursos { get; set; }
        public DbSet <Professor> Professors { get; set; }
        public DbSet <Disciplina> Disciplinas { get; set; }
    }
}