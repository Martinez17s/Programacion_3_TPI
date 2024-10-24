using Application.DTOs;
using Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISubjectService
    {
        Task<SubjectDto> CreateAsync(SubjectCreateRequest user);

        Task<SubjectDto> GetSubjectAsync(int id);

        Task<List<SubjectDto>> GetAllAsync();

        Task<SubjectDto> UpdateAsync(SubjectDto subject, int id);

        Task DeleteAsync(int id);
    }
}
