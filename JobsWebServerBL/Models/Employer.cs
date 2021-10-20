using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class Employer
    {
        public Employer()
        {
            JobApplications = new HashSet<JobApplication>();
            JobRequests = new HashSet<JobRequest>();
        }

        public int EmployerId { get; set; }
        public int UserId { get; set; }
        public bool IsEmployee { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
