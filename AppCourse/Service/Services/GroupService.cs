using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Groups;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IGroupTeacherRepository _groupTeacherRepository;
        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepository,
                            IMapper mapper,
                            IGroupTeacherRepository groupTeacherRepository)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
            _groupTeacherRepository = groupTeacherRepository;
        }

        public async Task CreateAsync(GroupCreateDto model)
        {
            var data = _mapper.Map<Group>(model);

            await _groupRepository.CreateAsync(data);
            await _groupTeacherRepository.CreateAsync(new GroupTeachers { GroupId = data.Id, TeacherId = model.teacherId });
        }

        public async Task DeleteAsync(int? id)
        {
        }

        public Task EditAsync(int? id, GroupEditDto model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            var datas = await _groupRepository.FindAllWithIncludes()
                                              .Include(m => m.Education).Include(m => m.Room)
                                              .Include(m => m.GroupTeachers)
                                              .ThenInclude(m => m.Teacher)
                                              .Include(m => m.GroupStudents)
                                              .ThenInclude(m => m.Student).ToListAsync();

            return _mapper.Map<IEnumerable<GroupDto>>(datas);
        }
           
    }
}
