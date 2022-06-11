using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public int UserTypeId { get; set; }
        public string Profession { get; set; }
        public string PrivateAnswer { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
