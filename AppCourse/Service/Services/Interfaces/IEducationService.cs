using Service.DTOs.Admin.Educations;

namespace Service.Services.Interfaces
{
    public interface IEducationService
    {
        Task CreateAsync(EducationCreateDto model);
        Task EditAsync(int? id, EducationEditDto model);
        Task DeleteAsync(int? id);
        Task<EducationDto> GetById(int id);
        Task<IEnumerable<EducationDto>> GetAll();
        Task<IEnumerable<EducationDto>> SortBy(string sortKey, bool isDescending);
        Task<IEnumerable<EducationDto>> SearchByName(string name);
    }
}
