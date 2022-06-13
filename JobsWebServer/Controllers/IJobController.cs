using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using JobsWebServer.DTO;
using JobsWebServerBL.Models;
using System.IO;


namespace JobsWebServer.Controllers
{
    [Route("iJobAPI")]
    [ApiController]
    
    public class IJobController : ControllerBase
    {
        //Connection to the DB Context via dependency injection
        IJobDBContext context;
      
        public IJobController(IJobDBContext context)
        {
            this.context = context;
        }

        //set the contact default photo image name
        public const string DEFAULT_PROFILE_PHOTO = "DefualtProfile.PNG";

     

        [Route("HelloWorld")]
        [HttpGet]
        public string BasicFunc()
        {
            return "Hello World!!";
        }


        [Route("Lucas")]
        [HttpGet]
        public string Lucas()
        {
            return "It's Lucas hereug!";
        }


        [Route("Time")]
        [HttpGet]
        public string GetTime()
        {
           
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm");

        }

        [Route("GetLookups")]
        [HttpGet]
        public LookUps GetLookups()
        {
            try
            {
                LookUps obj = new LookUps()
                {
                    //OccupationalAreas = context.OccupationalAreas.ToList(),
                    //Branches = context.Branches.ToList(),
                   
                };

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
                return obj;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }



        [Route("Login")]
        [HttpGet]
        public User Login([FromQuery] string email, [FromQuery] string pass)
        {
            User user = context.Login(email, pass);

            //Check user name and password
            if (user != null)
            {
                HttpContext.Session.SetObject("theUser", user);

                Response.StatusCode = (int)System.Net.HttpStatusCode.OK;

                //Important! Due to the Lazy Loading, the user will be returned with all of its contects!!!
                return user;
            }
            else
            {

                Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
                return null;
            }
        }

        
        [Route("EditProfile")]
        [HttpPost]
        public bool EditProfile([FromBody] User user)
        {

            if (user == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return false;
            }

            this.context.EditUser(user);
            HttpContext.Session.SetObject("theUser", user);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return true;

        }

        [Route("SignUp")]
        [HttpPost]
        public User SignUp([FromBody] User user)
        {
            
            if (user == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }

            this.context.AddUser(user);
            HttpContext.Session.SetObject("theUser", user);
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return context.Users.Include(u=>u.UserType).Where(u=>u.Email==user.Email).FirstOrDefault();

        }

        [Route ("GetUserTypes")]
        [HttpGet]
        public List<UserType> GetUserTypes()
        {
            return this.context.UserTypes.ToList(); 
        }

        [Route("IsNickNameExist")]
        [HttpGet]
        public bool IsNickNameExist([FromQuery] string nickname)
        {
            User user = this.context.Users.Where(u => u.Nickname == nickname).FirstOrDefault();
            if (user == null) 
            {
                return false;
            }
            else
            {
                return true;
            }
            
            //return (u != null);
        } 
        
        [Route("IsEmailExist")]
        [HttpGet]
        public bool IsEmailExist([FromQuery] string email)
        {
            User user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user == null) 
            {
                return false;
            }
            else
            {
                return true;
            }
            
           
        }

        [Route("IsPetNameCorrect")]
        [HttpGet]
        public bool IsPetNameCorrect([FromQuery] string email, [FromQuery] string petName)
        {
            User user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();
            //User won't be null bc it's already been checked
            bool isPetNameCorrect = user.PrivateAnswer.Equals(petName);
            return isPetNameCorrect; 

        }

        [Route("GetUser")]
        [HttpGet]
        public User GetUser([FromQuery] string email)
        {
            User user = this.context.Users.Where(u => u.Email == email).FirstOrDefault();
            return user;

        }

        [Route("GetCategories")]
        [HttpGet]
        public List<Category> GetCategories()
        {

            return context.GetCategories();

        }

        
        [Route("GetJobOffers")]
        [HttpGet]
        public List<JobOffer> GetJobOffers(int employerID)
        {

            return context.GetJobOffersPerUser(employerID);

        }

        [Route("IsEmployer")]
        [HttpGet]
        public bool IsEmployer([FromQuery] int userID)
        {
            return this.context.IsEmployer(userID);
        }



        [Route("GetJobOfferEmployees")]
        [HttpGet]
        //public List<JobOffer> GetJobOfferEmployees(int jobOfferID)
        //{

        //    //return context.GetJobOfferEmployees(jobOfferID);

        //}




        [Route("UploadImage")]
        [HttpPost]

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");
            //Check if user logged in and its ID is the same as the contact user ID
            if (user != null)
            {
                if (file == null)
                {
                    return BadRequest();
                }

                try
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/ProfileImages", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    return Ok(new { length = file.Length, name = file.FileName });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }
            return Forbid();
        }

        [Route("UploadImageJob")]
        [HttpPost]
        public async Task<IActionResult> UploadImageJob(IFormFile file)
        {
            User user = HttpContext.Session.GetObject<User>("theUser");
            //Check if user logged in and its ID is the same as the contact user ID
            if (user != null)
            {
                if (file == null)
                {
                    return BadRequest();
                }

                try
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/JobOfferImages", file.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }


                    return Ok(new { length = file.Length, name = file.FileName });
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return BadRequest();
                }
            }
            return Forbid();
        }

        [Route("AddJobOffer")]
        [HttpPost]
        public JobOffer AddJobOffer([FromBody] JobOffer jobOffer)
        {

            if (jobOffer == null)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return null;
            }

            this.context.AddJobOffer(jobOffer);
            //HttpContext.Session.SetObject("theUser", user);//Might not needed
            Response.StatusCode = (int)System.Net.HttpStatusCode.OK;
            return this.context.JobOffers.Where(j => j.JobOfferId == jobOffer.JobOfferId).FirstOrDefault(); ;

        }








        //[Route("UpdateContact")]
        //[HttpPost]
        //public UserContact UpdateContact([FromBody] UserContact contact)
        //{
        //    //If contact is null the request is bad
        //    if (contact == null)
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //        return null;
        //    }

        //    User user = HttpContext.Session.GetObject<User>("theUser");
        //    //Check if user logged in and its ID is the same as the contact user ID
        //    if (user != null && user.Id == contact.UserId)
        //    {

        //        //update contact to the DB by marking all entities that should be modified or added
        //        if (contact.ContactId > 0)
        //        {
        //            context.Entry(contact).State = EntityState.Modified;
        //        }
        //        else
        //        {
        //            context.Entry(contact).State = EntityState.Added;
        //        }

        //        foreach (ContactPhone cp in contact.ContactPhones)
        //        {
        //            if (cp.PhoneId > 0)
        //            {
        //                context.Entry(cp).State = EntityState.Modified;
        //            }
        //            else
        //            {
        //                context.Entry(cp).State = EntityState.Added;
        //            }
        //        }
        //        //Save change into the db
        //        context.SaveChanges();


        //        //Now check if an image exist for the contact (photo). If not, set the default image!
        //        var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", DEFAULT_PHOTO);
        //        var targetPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{contact.ContactId}.jpg");
        //        System.IO.File.Copy(sourcePath, targetPath);

        //        //return the contact with its new ID if that was a new contact
        //        return contact;
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        //        return null;
        //    }
        //}

        //[Route("GetPhoneTypes")]
        //[HttpGet]
        //public List<PhoneType> GetPhoneTypes()
        //{
        //    return context.PhoneTypes.ToList();
        //}


        //[Route("RemoveContact")]
        //[HttpPost]
        //public void RemoveContact([FromBody] UserContact contact)
        //{
        //    //If contact is null the request is bad
        //    if (contact == null)
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //        return;
        //    }
        //    User user = HttpContext.Session.GetObject<User>("theUser");
        //    //Check if user logged in and its ID is the same as the contact user ID
        //    if (user != null && user.Id == contact.UserId)
        //    {
        //        //First remove all contact phones
        //        foreach (ContactPhone c in contact.ContactPhones)
        //        {
        //            context.Entry(c).State = EntityState.Deleted;
        //        }
        //        //now remove the contact it self
        //        context.Entry(contact).State = EntityState.Deleted;
        //        context.SaveChanges();

        //        //now delete the photo image of the contact 
        //        var sourcePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", $"{contact.ContactId}.jpg");
        //        System.IO.File.Delete(sourcePath);
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        //        return;
        //    }
        //}

        //[Route("RemoveContactPhone")]
        //[HttpPost]
        //public void RemoveContactPhone([FromBody] ContactPhone phone)
        //{
        //    //If phone is null the request is bad
        //    if (phone == null || phone.Contact == null)
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
        //        return;
        //    }

        //    User user = HttpContext.Session.GetObject<User>("theUser");
        //    //Check if user logged in and its ID is the same as the contact user ID
        //    if (user != null && user.Id == phone.Contact.UserId)
        //    {
        //        //remove the phone
        //        context.Entry(phone).State = EntityState.Deleted;
        //        context.SaveChanges();
        //    }
        //    else
        //    {
        //        Response.StatusCode = (int)System.Net.HttpStatusCode.Forbidden;
        //        return;
        //    }
        //}

        //[Route("UploadImage")]
        //[HttpPost]

        //public async Task<IActionResult> UploadImage(IFormFile file)
        //{
        //    User user = HttpContext.Session.GetObject<User>("theUser");
        //    //Check if user logged in and its ID is the same as the contact user ID
        //    if (user != null)
        //    {
        //        if (file == null)
        //        {
        //            return BadRequest();
        //        }

        //        try
        //        {
        //            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", file.FileName);
        //            using (var stream = new FileStream(path, FileMode.Create))
        //            {
        //                await file.CopyToAsync(stream);
        //            }


        //            return Ok(new { length = file.Length, name = file.FileName });
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //            return BadRequest();
        //        }
        //    }
        //    return Forbid();
        //}





    }
}
