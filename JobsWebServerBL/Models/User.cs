using System;
using System.Collections.Generic;

#nullable disable

namespace JobsWebServerBL.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public int LastName { get; set; }
        public int Email { get; set; }
        public string Pass { get; set; }
        public int Nickname { get; set; }
        public int Birthday { get; set; }
        public int Gender { get; set; }
        public int UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }
    }
}
