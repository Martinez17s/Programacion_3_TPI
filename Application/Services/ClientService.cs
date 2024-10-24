
using Application.DTOs;
using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientService;
        public ClientService(IClientRepository clientService)
        {
            _clientService = clientService;
        }

        public async Task<List<SubjectDto>> GetClientSubjects(int clientId)
        {
            var subjects = _clientService.GetClientSubjects(clientId);
            var subjectsDto = new List<SubjectDto>();
            foreach (var subject in subjectsDto)
            {
                var subjectDto = new SubjectDto()
                {
                    Title = subject.Title,
                    Description = subject.Description,
                    ProfessorId = subject.ProfessorId,
                    Price = subject.Price,
                };
                subjectsDto.Add(subjectDto);
            }
            return subjectsDto;
        }
    }
}
