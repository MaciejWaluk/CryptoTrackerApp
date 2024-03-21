using AutoMapper;
using backend.Data;
using backend.ViewModels;

namespace backend.MappingProfiles
{
    public class CryptocurrencyProfile : Profile
    {
        public CryptocurrencyProfile()
        {
            CreateMap<CryptocurrencyViewmodel, Cryptocurrency>();
            CreateMap<Cryptocurrency, CryptocurrencyViewmodel>();
        }
    }
}
