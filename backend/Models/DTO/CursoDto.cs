using MyUniversityAPI.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyUniversityAPI.Models.DTO
{
    public class CursoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<DisciplinaDto> Disciplinas { get; set; }
    }
}