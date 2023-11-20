using MyUniversityAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models.Dto
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<DisciplinaDto> Disciplinas{ get; set; }
    }
}