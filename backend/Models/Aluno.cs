namespace MyUniversityAPP.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? NumeroMatricula { get; set; }
        // Supondo que um aluno pode estar matriculado em várias disciplinas
        public virtual List<Matricula> Matriculas { get; set; }

        public Aluno()
        {
            Nome = string.Empty;
            DataNascimento = DateTime.MinValue;
            NumeroMatricula = string.Empty;
            Matriculas = new List<Matricula>();

        }
    }
}
