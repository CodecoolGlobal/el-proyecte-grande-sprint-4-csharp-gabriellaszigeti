using Microsoft.EntityFrameworkCore;

namespace el_proyecte_grande_sprint_1.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

    }
}
