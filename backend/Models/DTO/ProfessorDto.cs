namespace MyUniversityAPP.Models.DTO
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
        public virtual List<DisciplinaDto> Disciplinas { get; set; }

        public ProfessorDto()
        {
            Nome = "";
            DataNascimento = DateTime.MinValue;
            Salario = 0;
            Disciplinas = new List<DisciplinaDto>();
        }
    }
}
