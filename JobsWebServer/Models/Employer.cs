using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServer.Models
{
    public partial class Employer
    {
        public Employer()
        {
            JobApplications = new HashSet<JobApplication>();
            JobOffers = new HashSet<JobOffer>();
            JobRequests = new HashSet<JobRequest>();
        }

        public int EmployerId { get; set; }
        public int UserId { get; set; }

        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
