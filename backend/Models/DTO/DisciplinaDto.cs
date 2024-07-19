namespace MyUniversityAPP.Models.DTO
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CursoId { get; set; }
        public int? ProfessorId { get; set; }
        public virtual CursoDto Curso { get; set; }
        public virtual ProfessorDto? Professor { get; set; }
        public virtual List<Matricula> Matriculas { get; set; }

        public DisciplinaDto()
        {
            Nome = string.Empty;
            Curso = new CursoDto();
            Matriculas = new List<Matricula>();
            ProfessorId = null;
        }

    }
}
