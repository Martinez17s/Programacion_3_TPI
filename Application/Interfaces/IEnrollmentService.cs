using Application.DTOs;
using Application.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<EnrollmentDto> CreateAsync(EnrollmentCreateRequest request);

        Task<EnrollmentDto> GetEnrollmentAsync(int id);

        Task<EnrollmentDto> GetAllAsync();

        Task<EnrollmentDto> UpdateAsync(EnrollmentDto enrollment);

        Task DeleteAsync(int id);
    }
}
