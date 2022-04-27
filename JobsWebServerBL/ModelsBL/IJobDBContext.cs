using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace JobsWebServerBL.Models
{
    public partial class IJobDBContext : DbContext
    {
        public User Login(string email, string pswd)
        {
            User user = this.Users.Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();

            return user;
        }

        public void AddUser(User u)
        {
            //יש להוסיף את Gender, UserTypeID לפי בחירתם 
            this.Users.Add(u);
            this.SaveChanges();
            
            
        }

        public void AddJobOffer(JobOffer j)
        {
            this.JobOffers.Add(j);
            this.SaveChanges();
        }
    }
}
