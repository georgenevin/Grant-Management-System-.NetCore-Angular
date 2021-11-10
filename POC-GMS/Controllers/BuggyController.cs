using data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GMS.Controllers
{
    public class BuggyController : BaseAPIController
    {

        private readonly DataContext _datacontext;
        public BuggyController(DataContext dataContext)
        {
            _datacontext = dataContext;
        }

        [HttpGet("auth")]
        public ActionResult<string>GetSecret()
        {
            return "secret text";
        }


        [HttpGet("not-found")]
        public ActionResult<UserDto>GetNotFound()
        {
            var thing = _datacontext.Users.Find(-1);
            if (thing == null)
            {
                return NotFound();
            }
            return Ok(thing);
        }

        [HttpGet("server-error")]
        public ActionResult<string> GetServerError()
        {
            
                var thing = _datacontext.Users.Find(-1);
                var thingToReturn = thing.ToString();
                return thingToReturn;
            
           
               
            
          
        }

        [HttpGet("bad-request")]

        public ActionResult<string>GetBadRequest()
        {
            return BadRequest("This is a bad request");
        }




    }
}
