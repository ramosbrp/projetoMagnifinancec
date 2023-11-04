using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroMatricula { get; set; }
        // Supondo que um aluno pode estar matriculado em várias disciplinas
        public virtual ICollection<Matricula> Matriculas { get; set; }

        public Aluno()
        {
            Matriculas = new HashSet<Matricula>();
        }
    }
}