using AutoMapper;
using Domain.Entities;
using Service.DTOs.Account;
using Service.DTOs.Admin.Cities;
using Service.DTOs.Admin.Countries;
using Service.DTOs.Admin.Educations;
using Service.DTOs.Admin.Groups;
using Service.DTOs.Admin.GroupTeachers;
using Service.DTOs.Admin.Rooms;
using Service.DTOs.Admin.Students;
using Service.DTOs.Admin.Teachers;

namespace Service.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryCreateDto, Country>();
            CreateMap<Country, CountryDto>();
            CreateMap<CountryEditDto, Country>();

            CreateMap<City, CityDto>().ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country.Name));
            CreateMap<CityCreateDto, City>();

            CreateMap<Education, EducationDto>();
            CreateMap<EducationCreateDto, Education>();
            CreateMap<EducationEditDto, Education>();

            CreateMap<RoomCreateDto, Room>();
            CreateMap<Room, RoomDto>();


            CreateMap<TeacherCreateDto, Teacher>();
            CreateMap<Teacher, TeacherDto>();

            CreateMap<Student, StudentDto>();

            CreateMap<Group, GroupDto>()
                .ForMember(d => d.Education, opt => opt.MapFrom(s => s.Education.Name))
                .ForMember(d => d.Room, opt => opt.MapFrom(s => s.Room.Name))
                .ForMember(d => d.Teachers, opt => opt.MapFrom(s => s.GroupTeachers.Select(m => new TeacherDto
                 {
                     Id = m.Teacher.Id,
                     Name = m.Teacher.Name,
                     Surname = m.Teacher.Surname,
                     Age = m.Teacher.Age,
                     Email = m.Teacher.Email,
                     Salary = m.Teacher.Salary
                 }).ToList()))
                .ForMember(d => d.Students, opt => opt.MapFrom(s => s.GroupStudents.Select(m => new StudentDto
                 {
                      Id = m.Student.Id,
                      Name = m.Student.Name,
                      Surname = m.Student.Surname,
                      Age = m.Student.Age,
                      Email = m.Student.Email,
                      Address = m.Student.Address
                 }).ToList()));


            CreateMap<GroupCreateDto, Group>();
            CreateMap<GroupEditDto, Group>();

            CreateMap<GroupTeacherCreateDto, GroupTeachers>();
            CreateMap<GroupTeachers, GroupTeacherDto>();

            CreateMap<StudentCreateDto, Student>();
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Groups, opt => opt.MapFrom(m => m.GroupStudents.Select(m => m.Group.Name)));

            CreateMap<RegisterDto, AppUser>();
            CreateMap<AppUser, UserDto>();

        }
    }
}
