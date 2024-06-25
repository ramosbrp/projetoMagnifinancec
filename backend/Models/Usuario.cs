namespace MyUniversityAPP.Models
{
    public class Usuario
    {
        public  int Id { get; set; }
        public  string Nome { get; set; }

        public Usuario()
        {
            Nome = string.Empty;
        }
    }
}
