using backend.Data;

namespace backend.Services
{
    public interface ICryptocurrencyService
    {
        Task<IEnumerable<Cryptocurrency>> GetAllCryptocurrencies();
        Task<Cryptocurrency> GetCryptocurrencyById(int id);
        Task<Cryptocurrency> AddCryptocurrency(Cryptocurrency cryptocurrency);
        Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrency);
        Task DeleteCryptocurrency(int id);
    }
}
