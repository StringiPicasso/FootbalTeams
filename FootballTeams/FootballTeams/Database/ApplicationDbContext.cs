using FootballTeams.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballTeams.Database
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<TeamName> TeamNames { get; set; }
    }
}
