namespace MyUniversityAPP.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public decimal Salario { get; set; }
        public virtual List<Disciplina> Disciplinas { get; set; } = new List<Disciplina>();

        public Professor()
        {
            Nome = string.Empty;
            DataNascimento = DateTime.MinValue;
            Salario = 0;
            Disciplinas = new List<Disciplina>(); 
        }

    }
}
