using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CryptocurrencyDbContext : DbContext
    {
        public CryptocurrencyDbContext(DbContextOptions<CryptocurrencyDbContext> options) : base(options)
        {
        }

        public DbSet<Cryptocurrency> Cryptocurrencies { get; set; }
    }
}
