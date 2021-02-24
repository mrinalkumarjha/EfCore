using EFCore5.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCore5.Data
{
    public class AppContext: DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("data source=INDEL5BL0528\\SQLEXPRESS;initial catalog=samuraidb");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
