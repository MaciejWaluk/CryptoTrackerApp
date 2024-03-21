using backend.Data;

namespace backend.Repositories
{
    public interface ICryptocurrencyRepository
    {
        Task<IEnumerable<Cryptocurrency>> GetAllCryptocurrencies();
        Task<Cryptocurrency> GetCryptocurrencyById(int id);
        Task<Cryptocurrency> AddCryptocurrency(Cryptocurrency cryptocurrency);
        Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrency);
        Task DeleteCryptocurrency(int id);
    }
}
