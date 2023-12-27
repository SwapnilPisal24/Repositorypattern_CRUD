using Microsoft.EntityFrameworkCore;
using Repositorypattern.Entities;

namespace Repositorypattern.repositories
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) :base(options)
        {
                
        }

        public DbSet<Country> countries { get; set; }
        public DbSet<State> states { get; set; } 
        public DbSet<City> cities { get; set; }


    }
}
