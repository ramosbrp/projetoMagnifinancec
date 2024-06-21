using Microsoft.EntityFrameworkCore;




namespace MyUniversityAPP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina DbSet<T> para cada entidade que você deseja incluir no seu modelo
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
