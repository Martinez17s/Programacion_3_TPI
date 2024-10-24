using Application.DTOs;
using Application.DTOs.Requests;


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
