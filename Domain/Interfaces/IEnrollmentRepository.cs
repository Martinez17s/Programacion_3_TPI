
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IEnrollmentRepository : IBaseRepository<Enrollment>
    {
        // Agrega métodos específicos para Enrollment si es necesario
        IEnumerable<Enrollment> GetEnrollmentsByClientId(int clientId);
    }
}
