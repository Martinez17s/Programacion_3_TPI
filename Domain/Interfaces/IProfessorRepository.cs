using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IProfessorRepository
    {
        Professor GetProfessorById(int id);
        IEnumerable<Professor> GetAllProfessors();
        void AddProfessor(Professor professor);
        void UpdateProfessor(Professor professor);
        void DeleteProfessor(int id);
    }
}
