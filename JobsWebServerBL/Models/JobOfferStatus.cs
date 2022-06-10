using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class JobOfferStatus
    {
        public JobOfferStatus()
        {
            JobOffers = new HashSet<JobOffer>();
            JobRequests = new HashSet<JobRequest>();
        }

        public int JobOfferStatusId { get; set; }
        public string JobOfferStatus1 { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
