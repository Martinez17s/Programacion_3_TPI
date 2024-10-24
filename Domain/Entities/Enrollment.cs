using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }

        public int ActivityId { get; set; }

        public Subject Subject { get; set; }

        public int ClientId { get; set; }
        
        public Client Client { get; set; }
    }
}
