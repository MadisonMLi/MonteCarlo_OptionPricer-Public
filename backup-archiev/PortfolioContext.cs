using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Catalog.Entities
{   
    public class PortfolioContext : DbContext
    {
        public virtual DbSet<Instrument> Instruments { get; set; }
        public virtual DbSet<InterestRate> InterestRates { get; set; }
        public virtual DbSet<Trade> Trades { get; set; }
        public virtual DbSet<InstType> InstTypes { get; set; }
        public virtual DbSet<Price> Prices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                => optionsBuilder.UseNpgsql("Host=localhost;Database=portfolio.db;Username=pgadmin;Password=password123");
    }
}