namespace MyUniversityAPP.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string NumeroMatricula { get; set; }
        // Supondo que um aluno pode estar matriculado em várias disciplinas
        public virtual List<Matricula> Matriculas { get; set; } = new List<Matricula>();
    }
}
