using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using models.Dtos;
using models.Models;

namespace POC_GMS.Controllers
{
    public class GrantProgramController : BaseAPIController
    {

        private IGrant _grants { get; set; }
        public GrantProgramController(IGrant grant)
        {
            _grants = grant;
        }

        [Authorize(Roles = "admin")]
        [HttpPost("SaveGrant")]
        public async Task<GrantDto> AddGrant(GrantDto grantProgram)
        {
            var program = await _grants.AddGrantProgram(grantProgram);
         
            return program;
        }

        [HttpGet("GetGrant")]
        public async Task<IEnumerable<GrantDto>> GetAllGrants()
        {
            var program = await _grants.GetAllGrants();
            return program;
        }



        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<GrantDto>DeleteGrant(int id)
        {
          
         
            return await _grants.DeleteGrant(id);
           
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
       public async Task<GrantDto>UpdateGrant(GrantDto program)
        {
            return await _grants.UpdateGrant(program);
        }
      

    }
}
