using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JobsWebServerBL.Models;
using System.IO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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




        [Route("/HelloWorld")]
        [HttpGet]
        public string BasicFunc()
        {
            return "Hello World!!";
        }


        [Route("/Lucas")]
        [HttpGet]
        public string Lucas()
        {
            return "It's Lucas here!";
        }


        [Route("/Time")]
        [HttpGet]
        public DateTime GetTime()
        {
           return DateTime.Now;

        }








        //// GET: api/<IJobController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<IJobController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<IJobController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<IJobController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<IJobController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
