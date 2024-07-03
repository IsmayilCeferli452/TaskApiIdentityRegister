using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Logging;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;
        private readonly ILogger<CountryService> _logger;

        public CountryService(ICountryRepository countryRepo,
                              IMapper mapper,
                              ILogger<CountryService> logger)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
            _logger= logger;
        }

        public async Task CreateAsync(CountryCreateDto model)
        {
            if (model is null) throw new ArgumentNullException();
            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null)
            {
                _logger.LogWarning("Id is null");
                throw new ArgumentNullException();
            }

            var existCountry = await _countryRepo.GetById((int)id);

            if (existCountry is null)
            {
                _logger.LogWarning("Data notfound");
                throw new NullReferenceException();
            }

            await _countryRepo.DeleteAsync(existCountry);

        }

        public async Task EditAsync(int? id, CountryEditDto model)
        {
            ArgumentNullException.ThrowIfNull(nameof(id));

            var existCountry = await _countryRepo.GetById((int)id) ?? throw new NullReferenceException();
            
            _mapper.Map(model, existCountry);

            await _countryRepo.EditAsync(existCountry);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<CountryDto> GetByIdAsync(int? id)
        {
            if(id is null) throw new ArgumentNullException();

            var existCountry = await _countryRepo.GetById((int)id);

            if (existCountry is null) throw new NullReferenceException();

            return _mapper.Map<CountryDto>(existCountry);
        }
    }
}
