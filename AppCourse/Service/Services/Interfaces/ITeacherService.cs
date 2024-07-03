using Service.DTOs.Admin.Teachers;

namespace Service.Services.Interfaces
{
    public interface ITeacherService
    {
        Task Create(TeacherCreateDto model );
        Task<IEnumerable<TeacherDto>> GetAll();
    }
}
