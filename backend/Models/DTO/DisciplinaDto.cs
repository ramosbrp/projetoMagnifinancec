namespace MyUniversityAPP.Models.DTO
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Matricula> Matriculas { get; set; }

        public DisciplinaDto()
        {
            Nome = string.Empty;
            Matriculas = new List<Matricula>();
        }

    }
}
