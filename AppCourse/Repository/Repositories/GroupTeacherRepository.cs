using Domain.Entities;
using Repository.Data;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class GroupTeacherRepository : BaseRepository<GroupTeachers>, IGroupTeacherRepository
    {
        public GroupTeacherRepository(AppDbContext context) : base(context)
        {
        }
    }
}
