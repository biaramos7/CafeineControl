using CaffeineControlAPI.Data.Map;
using CaffeineControlAPI.Entity;
using Microsoft.EntityFrameworkCore;

namespace CaffeineControlAPI.Data
{
    public class CoffeeContext : DbContext
    {
        private readonly string connectionString = "";


        public CoffeeContext(DbContextOptions<CoffeeContext> options) : base(options) { }

        public CoffeeContext(string ConnectionString)
        {
            this.connectionString = ConnectionString;
        }
        
        public DbSet<Coffee> Coffee { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            if (connectionString != string.Empty) optionsBuilder.UseNpgsql(this.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coffee>(new Coffee_map().Configure);
        }
    }
}
