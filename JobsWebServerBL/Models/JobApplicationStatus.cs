using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class JobApplicationStatus
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }

        public virtual JobApplication JobApplication { get; set; }
    }
}
