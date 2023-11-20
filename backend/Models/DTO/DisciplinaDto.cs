using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models.DTO
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CursoId{ get; set; }
        public int ProfessorId{ get; set; }
        public List<Matricula> Matriculas{ get; set; }
    }
}