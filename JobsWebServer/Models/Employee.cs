using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServer.Models
{
    public partial class Employee
    {
        public Employee()
        {
            JobApplications = new HashSet<JobApplication>();
        }

        public int EmployeeId { get; set; }
        public int UserId { get; set; }
        public bool Employeed { get; set; }
        public int RatingId { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual JobRequest JobRequest { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
