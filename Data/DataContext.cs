using Microsoft.EntityFrameworkCore;
using CRUD.Entities;

namespace CRUD.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base (options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
    }
}