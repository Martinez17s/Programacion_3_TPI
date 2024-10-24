using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        public int SubjectId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public int ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
