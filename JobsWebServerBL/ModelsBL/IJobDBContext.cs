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
             
            this.Users.Add(u);
            this.SaveChanges();
            if (u.UserTypeId == 1)
            {
                Employer e = new Employer() { UserId = u.UserId, EmployerId = u.UserId };
                this.Employers.Add(e);
            }
            else
            {
                Employee e = new Employee() { UserId = u.UserId, EmployeeId = u.UserId, Employeed=false, RatingId=0};
                this.Employees.Add(e);
            }
            this.SaveChanges();
            
            
        }

        public void AddJobOffer(JobOffer j)
        {
            this.JobOffers.Add(j);
            this.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return Categories.ToList<Category>();
        }
    }
}
