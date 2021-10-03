using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class JobOfferStatus
    {
        public JobOfferStatus()
        {
            JobRequests = new HashSet<JobRequest>();
        }

        public int JobOfferStatusId { get; set; }
        public string JobOfferStatus1 { get; set; }

        public virtual JobOffer JobOffer { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
