using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<City>> GetAllWithCountryAsync()
        {
            return await _context.Cities.Include(m => m.Country).ToListAsync();
        }

        public async Task<IEnumerable<City>> FilterAsync(string name, string countryName)
        {
            var query = _entities.AsQueryable();

            if (name is not null)
            {
                query = query.Where(m => m.Name == name);
            }

            if (countryName is not null)
            {
                query = query.Where(m => m.Country.Name == countryName);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<City>> GetPaginateDatasAsync(int page, int take)
        {
            return await _entities.Skip((page - 1) * take).Take(take).ToListAsync();
        }
    }
}
