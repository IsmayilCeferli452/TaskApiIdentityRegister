using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class EducationRepository : BaseRepository<Education>, IEducationRepository
    {
        public EducationRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Education>> SortBy(string sortKey, bool isDescending)
        {
            var query = _entities.AsQueryable();

            switch (sortKey)
            {
                case "Name":
                    query = isDescending == true ? query.OrderByDescending(m => m.Name) : query.OrderBy(m => m.Name);
                    break;
            }
            return await query.ToListAsync();
        }
    }
}
