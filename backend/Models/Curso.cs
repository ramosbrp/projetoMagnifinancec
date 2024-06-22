using MyUniversityAPP.Models.DTO;

namespace MyUniversityAPP.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual List<Disciplina> Disciplinas { get; set; } 

        
    }
}
