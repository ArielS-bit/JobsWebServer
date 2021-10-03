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
            JobOffers = new HashSet<JobOffer>();
        }

        public int EmployerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public bool IsEmployee { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<JobApplication> JobApplications { get; set; }
        public virtual ICollection<JobOffer> JobOffers { get; set; }
    }
}
