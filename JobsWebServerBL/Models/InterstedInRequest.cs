using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class InterstedInRequest
    {
        public int Id { get; set; }
        public int JobRequestId { get; set; }
        public int EmployerId { get; set; }

        public virtual JobRequest JobRequest { get; set; }
    }
}
