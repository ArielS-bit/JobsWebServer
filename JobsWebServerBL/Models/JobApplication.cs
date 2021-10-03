using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class JobApplication
    {
        public int AppId { get; set; }
        public int EmployeeId { get; set; }
        public int JobOfferId { get; set; }
        public int AppStatus { get; set; }
        public int EmployerId { get; set; }

        public virtual JobApplicationStatus AppStatusNavigation { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobOffer JobOffer { get; set; }
    }
}
