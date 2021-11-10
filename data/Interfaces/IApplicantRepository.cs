using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces
{
  public  interface IApplicantRepository
    {

        Task<IEnumerable<CountryModel>> GetCountries();

        Task<IEnumerable<StateModel>> GetStates(int countyId);

        Task<ApplicantModel> SaveApplicant(ApplicantModel applicant);

        Task<IEnumerable<ApplicantEducationModel>> SaveApplicantEdctnDetails(IEnumerable<ApplicantEducationModel> education);

        Task<bool> SaveApplicantStatus(ReviewModel review);
    }
}
