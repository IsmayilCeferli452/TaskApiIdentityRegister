using Service.DTOs.Admin.Groups;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        Task CreateAsync(GroupCreateDto model);
        Task EditAsync(int? id, GroupEditDto model);
        Task DeleteAsync(int? id);
        Task<IEnumerable<GroupDto>> GetAllAsync();
    }
}
