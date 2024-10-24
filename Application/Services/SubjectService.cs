using Application.DTOs;
using Application.DTOs.Requests;
using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _activityRepositiry;
        public SubjectService(ISubjectRepository activityRepository)
        {
            _activityRepositiry = activityRepository;
        }

        public async Task<SubjectDto> CreateAsync(SubjectCreateRequest request)
        {
            var Subject = new Subject();
            Subject.Title = request.Title;
            Subject.Description = request.Description;
            Subject.ProfessorId = request.ProfessorId;
            Subject.Price = request.Price;

            _ = await _SubjectRepositiry.CreateAsync(Subject);

            var dto = new SubjectDto();
            dto.ActivityId = Subject.SubjectId;
            dto.Title = Subject.Title;
            dto.Description = Subject.Description;
            dto.ProfessorId = Subject.ProfessorId;
            dto.Price = Subject.Price;

            return dto;
        }

        public async Task<SubjectyDto> GetSubjectAsync(int id)
        {
            var result = await _SubjectRepositiry.GetByIdAsync(id);
            if (result == null)
                throw new Exception("Subject not found");

            var SubjectDto = new SubjectDto();
            SubjectDto.SubjectId = result.SubjectId;
            SubjectDto.Title = result.Title;
            SubjectDto.Description = result.Description;
            SubjectDto.ProfessorId= result.ProfessorId;
            SubjectDto.Price = result.Price;
            
            return SubjectDto;
        }

        public async Task<List<SubjectDto>> GetAllAsync()
        {
            var result = await _subjectRepositiry.GetAllAsync();
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
                resultDto.Add(subjectDto);
            }
            return resultDto;
        }

        public async Task<SubjectDto> UpdateAsync(SubjectDto subjectDto, int id)
        {
            var subject = await _activityRepositiry.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("Activity not found");

            subject.Title = subjectDto.Title;
            subject.Description = subjectDto.Description;
            subject.Price = subjectDto.Price;
            subject.ProfessorId = subjectDto.ProfessorId;

            await _subjectRepositiry.UpdateAsync(subject);

            var dto = new SubjectDto()
            {
                SubjectId = subject.SubjectId,
                Title = subject.Title,
                Description = subject.Description,
                Price = subject.Price,
                ProfessorId = subject.ProfessorId,
            };

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            var subject = await _subjectRepositiry.GetByIdAsync(id);
            if (subject == null)
                throw new Exception("subject not found");

            await _subjectRepositiry.DeleteAsync(subject);
        }
    }
}
