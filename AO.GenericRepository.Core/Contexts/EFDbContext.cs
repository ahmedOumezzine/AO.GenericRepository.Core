using Microsoft.EntityFrameworkCore;

namespace AO.GenericRepository.Core.Contexts
{
    public class EFDbContext : DbContext
    {


        public EFDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}