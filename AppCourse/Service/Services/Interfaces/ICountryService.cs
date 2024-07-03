using Service.DTOs.Admin.Countries;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task CreateAsync(CountryCreateDto model);
        Task<CountryDto> GetByIdAsync(int? id);
        Task DeleteAsync(int? id);
        Task EditAsync(int? id, CountryEditDto model);
    }
}
