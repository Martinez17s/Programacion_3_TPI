using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepositiry;
        public SubjectService(ISubjectRepository subjectRepository)
        {
            _subjectRepositiry = subjectRepository;
        }

        public async Task<SubjectDto> CreateAsync(SubjectCreateRequest request)
        {
            var Subject = new Subject();
            Subject.Title = request.Title;
            Subject.Description = request.Description;
            Subject.ProfessorId = request.ProfessorId;

            _ = await _SubjectRepository.CreateAsync(Subject);

            var dto = new SubjectDto();
            dto.SubjectId = Subject.SubjectId;
            dto.Title = Subject.Title;
            dto.Description = Subject.Description;
            dto.ProfessorId = Subject.ProfessorId;

            return dto;
        }

        public async Task<SubjectDto> GetSubjectAsync(int id)
        {
            var result = await _SubjectRepository.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Subject not found");

            var SubjectDto = new SubjectDto();
            SubjectDto.SubjectId = result.SubjectId;
            SubjectDto.Title = result.Title;
            SubjectDto.Description = result.Description;
            SubjectDto.ProfessorId= result.ProfessorId;

            
            return SubjectDto;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var result = await _subjectRepository.GetAllAsync();
            var resultDto = new List<SubjectDto>();
            foreach (var aubject in result)
            {
                var activityDto = new SubjectDto()
                {
                    SubjectId = subject.SubjectId,
                    Title = subject.Title,
                    Description = subject.Description,
                    Price = subject.Price,
                    ProfessorId = subject.ProfessorId,
                };
                resultDto.Add(SubjectDto);
            }
            return resultDto;
        }

        public async Task<SubjectDto> UpdateAsync(SubjectDto subjectDto, int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Activity not found");

            subject.Title = subjectDto.Title;
            subject.Description = subjectDto.Description;
            subject.ProfessorId = subjectDto.ProfessorId;

            await _subjectRepository.UpdateAsync(subject);

            var dto = new SubjectDto()
            {
                SubjectId = subject.SubjectId,
                Title = subject.Title,
                Description = subject.Description,
                ProfessorId = subject.ProfessorId,
            };

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _subjectRepository.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("subject not found");

            await _subjectRepository.DeleteAsync(subject);
        }
    }
}
