namespace MyUniversityAPP.Models.DTO
{
    public class DisciplinaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Matricula> Matriculas { get; set; }

    }
}
