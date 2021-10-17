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
        public Employee Login(string email, string pswd)
        {

            Employee emp = this.Employees.Where(u => u.Email == email && u.Pass == pswd).FirstOrDefault();
            return emp;
        }
    }
}
