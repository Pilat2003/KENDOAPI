using Microsoft.EntityFrameworkCore;
using Kendo.Models;

namespace Kendo.Models
{
    public class KendoDBContext : DbContext
    {
        public KendoDBContext(DbContextOptions opt): base(opt)
        {

        }
        public DbSet<UserStatistic> UserStatistics { get; set; }
        public DbSet<BattleStatistic> BattleStatistics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

    }
}
