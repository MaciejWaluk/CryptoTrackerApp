using backend.Services;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using backend.ViewModels;
using backend.Data;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptocurrenciesController : ControllerBase
    {
        private readonly ICryptocurrencyService _cryptocurrencyService;
        private readonly IMapper _mapper;


        public CryptocurrenciesController(ICryptocurrencyService cryptocurrencyService, IMapper mapper)
        {
            _cryptocurrencyService = cryptocurrencyService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCryptocurrencies()
        {
            var cryptocurrencies = await _cryptocurrencyService.GetAllCryptocurrencies();
            var cryptocurrenciesViewModels = _mapper.Map<IEnumerable<Cryptocurrency>,IEnumerable<CryptocurrencyViewmodel>>(cryptocurrencies);
            return Ok(cryptocurrenciesViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCryptocurrencyById(int id)
        {
            try
            {
                var cryptocurrency = await _cryptocurrencyService.GetCryptocurrencyById(id);
                var cryptocurrencyViewModel = _mapper.Map<Cryptocurrency,CryptocurrencyViewmodel>(cryptocurrency);
                return Ok(cryptocurrencyViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCryptocurrency(CryptocurrencyViewmodel cryptocurrencyViewmodel)
        {
            var cryptocurrency = _mapper.Map<CryptocurrencyViewmodel,Cryptocurrency>(cryptocurrencyViewmodel);
            var addedCryptocurrency = await _cryptocurrencyService.AddCryptocurrency(cryptocurrency);

            var addedCryptocurrencyViewModel = _mapper.Map<Cryptocurrency, CryptocurrencyViewmodel>(addedCryptocurrency);

            cryptocurrencyViewmodel.Id = cryptocurrency.Id;
            return CreatedAtAction(nameof(GetCryptocurrencyById), new { id = addedCryptocurrency.Id }, addedCryptocurrencyViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCryptocurrency(int id, CryptocurrencyViewmodel cryptocurrencyViewmodel)
        {
            if (id != cryptocurrencyViewmodel.Id)
            {
                return BadRequest();
            }
            try
            {
                var existingCryptocurrency = await _cryptocurrencyService.GetCryptocurrencyById(id);
                _mapper.Map(cryptocurrencyViewmodel, existingCryptocurrency);
                await _cryptocurrencyService.UpdateCryptocurrency(existingCryptocurrency);

                var updatedCryptocurrencyViewModel = _mapper.Map<Cryptocurrency, CryptocurrencyViewmodel>(existingCryptocurrency);
                return Ok(updatedCryptocurrencyViewModel);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCryptocurrency(int id)
        {
            try
            {
                await _cryptocurrencyService.DeleteCryptocurrency(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }

        }






    }
}
