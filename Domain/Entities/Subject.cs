using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubjectId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public int Price { get; set; }

        public int ProfessorId { get; set; }

        public Professor? Professor { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
