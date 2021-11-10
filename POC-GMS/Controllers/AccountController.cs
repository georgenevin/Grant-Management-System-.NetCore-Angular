using business.Interfaces;
using data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Microsoft.Extensions.Logging;

namespace POC_GMS.Controllers
{

    public class AccountController : BaseAPIController
    {

        private readonly IUser _user;
        private readonly ILogger<AccountController> _logger; 
        public AccountController(IUser user, ILogger<AccountController> logger)
        {
            _user = user;
            _logger = logger;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await _user.IsUserExist(registerDto.Email))
            {
                return BadRequest("User Already Exist");
            }
            var addedUser = await _user.AddUser(registerDto);

            return addedUser;


        }

        [HttpPost("Login")]
     

        public async Task<ActionResult<UserDto>>Login(LoginDto login)
        {

        
                var user = await _user.GetUser(login.Email);
                if (user == null)
                {
                    return Unauthorized("No User Found !");
                }
                if (!user.Password.Equals(login.Password))
                {
                    return Unauthorized("Incorrect Password!");
                }

                return user;

        }



     

    }
}
