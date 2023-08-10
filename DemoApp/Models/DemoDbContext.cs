using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models
{
    public class DemoDbContext : AO.GenericRepository.Core.Contexts.EFDbContext 
    {

        public DemoDbContext(DbContextOptions<DemoDbContext> options) :base(options)
        {

        }

        public DbSet<Student> Student { get; set; }

    }
}
