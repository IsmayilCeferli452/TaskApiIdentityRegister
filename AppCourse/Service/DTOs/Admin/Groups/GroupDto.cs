using Service.DTOs.Admin.Students;
using Service.DTOs.Admin.Teachers;

namespace Service.DTOs.Admin.Groups
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Education { get; set; }
        public string Room { get; set; }
        public IEnumerable<TeacherDto> Teachers { get; set; }
        public IEnumerable<StudentDto> Students { get; set; }
    }
}
