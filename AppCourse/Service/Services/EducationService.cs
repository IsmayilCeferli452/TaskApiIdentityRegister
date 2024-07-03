using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Educations;
using Service.Helpers.Exceptions;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class EducationService : IEducationService
    {
        private readonly IEducationRepository _educationRepo;
        private readonly IMapper _mapper;

        public EducationService(IEducationRepository educationRepo,IMapper mapper)
        {
            _educationRepo = educationRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(EducationCreateDto model)
        {
            await _educationRepo.CreateAsync(_mapper.Map<Education>(model));
        }

        public async Task DeleteAsync(int? id)
        {
            if (id is null) throw new ArgumentNullException();

            var education = await _educationRepo.GetById((int)id);

            if (education is null) throw new NotFoundException("Education was not found");

            await _educationRepo.DeleteAsync(_mapper.Map<Education>(education));
        }

        public async Task EditAsync(int? id, EducationEditDto model)
        {
            if (id is null) throw new ArgumentNullException();

            var education = await _educationRepo.GetById((int)id);

            if (education is null) throw new NotFoundException("Education was not found");

            await _educationRepo.EditAsync(_mapper.Map(model, education));
        }

        public async Task<IEnumerable<EducationDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.GetAllAsync());
        }

        public async Task<EducationDto> GetById(int id)
        {
            return _mapper.Map<EducationDto>(await _educationRepo.GetById(id));
        }

        public async Task<IEnumerable<EducationDto>> SearchByName(string name)
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.FindAll(m => m.Name.Contains(name)));
        }

        public async Task<IEnumerable<EducationDto>> SortBy(string sortKey, bool isDescending)
        {
            return _mapper.Map<IEnumerable<EducationDto>>(await _educationRepo.SortBy(sortKey, isDescending));
        }
    }
}
