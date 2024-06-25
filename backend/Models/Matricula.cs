namespace MyUniversityAPP.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int DisciplinaId { get; set; }
        public decimal Nota { get; set; }
        public virtual Aluno Aluno { get; set; }
        public virtual Disciplina Disciplina { get; set; }

        public Matricula()
        {
            Aluno = new Aluno();
            Disciplina = new Disciplina();
        }
    }
}
