using business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GMS.Controllers
{
    public class ApplicantController : BaseAPIController
    {
        private readonly IUser _user;
        private readonly IApplicant _applicant;
        public ApplicantController(IUser user, IApplicant applicant)
        {
            _user= user;
            _applicant = applicant;
         }

        [HttpGet("{id}")]
        public async Task<ActionResult<LoggedApplicantDto>>GetApplicant(string id)
        {
            var applicant=await  _user.GetLoggedApplicant(id);
            return applicant;
            
        }

        [HttpGet("Country")]
        public async Task<IEnumerable<CountryModel>>GetAllCountry()
        {
            var countries = await _applicant.GetCountryList();

            return countries;
        }

        [HttpGet("State{id}")]
        public async Task<IEnumerable<StateDto>> GetAllStates(string id)
        {

            var countryId = Convert.ToInt32(id);   
            var states = await _applicant.GetStateList(countryId);

            return states;
        }

        [HttpPost("AddApplicant")]
        public async Task<ActionResult> AddApplicant(ApplicantDto applicantDto)
        {
            var applicant =await  _applicant.SaveApplicant(applicantDto);
         
            return Ok();

        }




    }
}
