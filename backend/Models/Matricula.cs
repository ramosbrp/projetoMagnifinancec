using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public decimal Nota { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }
    }
}