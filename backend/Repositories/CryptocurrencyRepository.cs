using backend.Data;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CryptocurrencyRepository : ICryptocurrencyRepository
    {

        private readonly CryptocurrencyDbContext _context;

        public CryptocurrencyRepository(CryptocurrencyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Cryptocurrency>> GetAllCryptocurrencies()
        {
            return await _context.Set<Cryptocurrency>().ToListAsync();
        }
        public async Task<Cryptocurrency> GetCryptocurrencyById(int id)
        {
            var cryptocurrency = await _context.Set<Cryptocurrency>().FindAsync(id);

            if(cryptocurrency == null)
            {
                throw new Exception("Cryptocurrency not found");
            }
            return cryptocurrency;
        }

        public async Task<Cryptocurrency> AddCryptocurrency(Cryptocurrency cryptocurrency)
        {
            await _context.AddAsync(cryptocurrency);
            await _context.SaveChangesAsync();
            return cryptocurrency;
        }

        public async Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrency)
        {

            var existingCryptocurrency = await _context.Set<Cryptocurrency>().FindAsync(cryptocurrency.Id);
            if (existingCryptocurrency == null)
            {
                throw new KeyNotFoundException("Cryptocurrency not found");
            }

            _context.Update(cryptocurrency);
            await _context.SaveChangesAsync();
            return cryptocurrency;
        }

        public async Task DeleteCryptocurrency(int id)
        {
            var cryptocurrency = await _context.Set<Cryptocurrency>().FindAsync(id);
            if(cryptocurrency == null)
            {
                throw new Exception("Cryptocurrency not found");
            }
            _context.Remove(cryptocurrency);
            await _context.SaveChangesAsync();
        }



    }
}
