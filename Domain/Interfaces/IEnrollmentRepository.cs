
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        // Agrega m�todos espec�ficos para Enrollment si es necesario
        IEnumerable<Enrollment> GetEnrollmentsByClientId(int clientId);
    }
}
