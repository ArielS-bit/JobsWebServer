using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class Rating
    {
        public Rating()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int RatingId { get; set; }
        public string RatingName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
