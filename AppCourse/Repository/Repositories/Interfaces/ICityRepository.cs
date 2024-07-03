using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<IEnumerable<City>> GetAllWithCountryAsync();
        Task<IEnumerable<City>> FilterAsync(string name, string countryName);
        Task<IEnumerable<City>> GetPaginateDatasAsync(int page, int take);
    }
}
