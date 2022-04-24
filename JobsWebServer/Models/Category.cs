using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServer.Models
{
    public partial class Category
    {
        public Category()
        {
            JobOffers = new HashSet<JobOffer>();
            JobRequests = new HashSet<JobRequest>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
