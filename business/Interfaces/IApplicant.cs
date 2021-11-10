using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
  public  interface IApplicant
    {

        Task<IEnumerable<CountryModel>> GetCountryList();

        Task<IEnumerable<StateDto>> GetStateList(int countyId);

        Task<ApplicantModel> SaveApplicant(ApplicantDto applicant);

       
    }
}
