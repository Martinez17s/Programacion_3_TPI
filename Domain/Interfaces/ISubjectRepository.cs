using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ISubjectRepository : IBaseRepository<Subject>
    {
        // Agrega métodos específicos para Subject si es necesario
        Task<List<Activity>> GetActivitiesByProfessorIdAsync(int professorId, CancellationToken cancellationToken = default);
    }
}
