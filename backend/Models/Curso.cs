using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }

        public Curso()
        {
            Disciplinas = new HashSet<Disciplina>();
        }
    }
}