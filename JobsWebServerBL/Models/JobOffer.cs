using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
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
        public string Topic { get; set; }
        public string Content { get; set; }
        public bool IsPrivate { get; set; }
        public int JobOfferStatusId { get; set; }
        public int CommentId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Comment CommentNavigation { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobOfferStatus JobOfferStatus { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }
    }
}
