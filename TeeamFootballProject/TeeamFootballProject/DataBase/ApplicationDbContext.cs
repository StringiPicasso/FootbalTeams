using Microsoft.EntityFrameworkCore;
using TeeamFootballProject.Models;

namespace TeeamFootballProject.DataBase
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<TeamNames> Teams { get; set; }
    }
}
