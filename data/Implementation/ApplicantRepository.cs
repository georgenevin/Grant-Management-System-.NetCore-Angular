using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Implementation
{
  public  class ApplicantRepository: IApplicantRepository
    {


        private DataContext _context;
        public ApplicantRepository(DataContext dataContext)
        {
            _context = dataContext;
        }


        public async Task<IEnumerable<CountryModel>>GetCountries()
        {

            var countries=await _context.Country.ToListAsync();
            return countries;
        }

        public async Task<IEnumerable<StateModel>>GetStates(int countyId)
        {
            var states = await _context.States.Include(x=>x.Country).Where(x=>x.Country.Country_Id == countyId).ToListAsync();
            return states;
        }


        public async Task<ApplicantModel> SaveApplicant(ApplicantModel applicant)
        {
              _context.ApplicationDetail.Add(applicant);
                await _context.SaveChangesAsync();

            
        
       
            return applicant;
        }

        public async Task<IEnumerable<ApplicantEducationModel>> SaveApplicantEdctnDetails(IEnumerable<ApplicantEducationModel> educations)
        {
            _context.EducationDetails.AddRange(educations);
            await _context.SaveChangesAsync();
            return educations;

        }

        public async Task<bool> SaveApplicantStatus(ReviewModel review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
            return true;

        }


    }
}
