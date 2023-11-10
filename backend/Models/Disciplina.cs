using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Disciplina
    {
        public int DisciplinaId { get; set; }
        public string Nome { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<Matricula> Matriculas { get; set; }

        public Disciplina()
        {
            Matriculas = new HashSet<Matricula>();
        }
    }
}