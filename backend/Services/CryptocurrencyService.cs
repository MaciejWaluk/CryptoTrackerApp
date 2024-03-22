using backend.Data;
using backend.Repositories;
using Microsoft.AspNetCore.Components.Web;

namespace backend.Services
{
    public class CryptocurrencyService : ICryptocurrencyService
    {

        private readonly ICryptocurrencyRepository _cryptocurrencyRepository;

        public CryptocurrencyService(ICryptocurrencyRepository cryptocurrencyRepository)
        {
            _cryptocurrencyRepository = cryptocurrencyRepository;
        }
        public async Task<IEnumerable<Cryptocurrency>> GetAllCryptocurrencies()
        {
            return await _cryptocurrencyRepository.GetAllCryptocurrencies();
        }
        public async Task<Cryptocurrency> GetCryptocurrencyById(int id)
        {
            return await _cryptocurrencyRepository.GetCryptocurrencyById(id);
        }

        public async Task<Cryptocurrency> AddCryptocurrency(Cryptocurrency cryptocurrency)
        {
            if (ValidateCryptocurrency(cryptocurrency))
            {
                return await _cryptocurrencyRepository.AddCryptocurrency(cryptocurrency);
            }
            else
            {
                throw new ArgumentException("Invalid cryptocurrency data");
            }
        }


        public async Task<Cryptocurrency> UpdateCryptocurrency(Cryptocurrency cryptocurrency)
        {
            if (ValidateCryptocurrency(cryptocurrency))
            {
                return await _cryptocurrencyRepository.UpdateCryptocurrency(cryptocurrency);
            }
            else
            {
                throw new ArgumentException("Invalid cryptocurrency data");
            }
        }
        public async Task DeleteCryptocurrency(int id)
        {
           await _cryptocurrencyRepository.DeleteCryptocurrency(id);
        }

        private bool ValidateCryptocurrency(Cryptocurrency cryptocurrency)
        {
            if(string.IsNullOrWhiteSpace(cryptocurrency.Name) || string.IsNullOrWhiteSpace(cryptocurrency.Symbol))
            {
                return false;
            }
            if(cryptocurrency.circulatingSupply < 0 || cryptocurrency.totalSupply < 0)
            {
                return false;
            }
            if(cryptocurrency.circulatingSupply > cryptocurrency.totalSupply)
            {
                return false;
            }

            return true;
        }   
    }
}
