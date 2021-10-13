using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
            return "It's Lucas here!";
        }


        [Route("Time")]
        [HttpGet]
        public DateTime GetTime()
        {
            return DateTime.Now;

        }

    }
}
