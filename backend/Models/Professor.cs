using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
        // Supondo que um professor pode lecionar várias disciplinas
        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public Professor()
        {
            Disciplinas = new HashSet<Disciplina>();
        }
    }
}