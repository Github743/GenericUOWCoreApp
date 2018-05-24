using CoreApp.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreApp.DataProvider.DataContext
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {

        }

        public DbSet<Employee> Employee { get; set; }
    }
}
