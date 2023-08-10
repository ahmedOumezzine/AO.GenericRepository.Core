using Microsoft.EntityFrameworkCore;

namespace AO.GenericRepository.Core.Contexts
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<DbContext> options)
            : base(options)
        {
        }


    }
}