using Microsoft.EntityFrameworkCore;

namespace MafiaGame
{
    public class GameContext : DbContext
    {
        public DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=mafia.db");
        }
    }
}