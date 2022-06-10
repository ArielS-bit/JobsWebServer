using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServer.Models
{
    public partial class JobOffer
    {
        public JobOffer()
        {
            JobApplications = new HashSet<JobApplication>();
        }

        public int JobOfferId { get; set; }
        public int CategoryId { get; set; }
        public int EmployerId { get; set; }
        public bool Applied { get; set; }
        public int NumApplied { get; set; }
        public string JobTitle { get; set; }
        public int? RequiredAge { get; set; }
        public int? RequiredEmployees { get; set; }
        public string JobOfferDescription { get; set; }
        public bool IsPrivate { get; set; }
        public int JobOfferStatusId { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public int? CommentId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Comment CommentNavigation { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobOfferStatus JobOfferStatus { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
