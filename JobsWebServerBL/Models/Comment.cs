using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class Comment
    {
        public Comment()
        {
            JobOffers = new HashSet<JobOffer>();
            JobRequests = new HashSet<JobRequest>();
        }

        public int CommentId { get; set; }
        public int Content { get; set; }
        public int JobOfferId { get; set; }
        public int JobRequestId { get; set; }
        public int Likes { get; set; }

        public virtual ICollection<JobOffer> JobOffers { get; set; }
        public virtual ICollection<JobRequest> JobRequests { get; set; }
    }
}
