using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class JobRequest
    {
        public JobRequest()
        {
            Comments = new HashSet<Comment>();
            InterstedInRequests = new HashSet<InterstedInRequest>();
        }

        public int JobRequestId { get; set; }
        public string Topic { get; set; }
        public string Content { get; set; }
        public bool IsApplied { get; set; }
        public int EmployeeId { get; set; }
        public int EmployerId { get; set; }
        public int CommentId { get; set; }
        public int CategoryId { get; set; }
        public int JobOfferStatusId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Comment Comment { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Employer Employer { get; set; }
        public virtual JobOfferStatus JobOfferStatus { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<InterstedInRequest> InterstedInRequests { get; set; }
    }
}
