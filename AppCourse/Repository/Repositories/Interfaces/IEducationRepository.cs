using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface IEducationRepository : IBaseRepository<Education>
    {
        Task<IEnumerable<Education>> SortBy(string sortKey, bool isDescending);
    }
}
