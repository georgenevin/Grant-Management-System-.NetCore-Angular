using AutoMapper;
using business.Interfaces;
using data.Interfaces;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace business.Implementation
{
    public class Applicant : IApplicant
    {


        public IApplicantRepository _applicant { get; set; }
        public IMapper _mapper { get; set; }
        public Applicant(IApplicantRepository applicantRepository, IMapper mapper)
        {
            _applicant = applicantRepository;
            _mapper = mapper;

        }

        public async Task<IEnumerable<CountryModel>> GetCountryList()
        {
            var countryList = await _applicant.GetCountries();
            return countryList;
        }


        public async Task<IEnumerable<StateDto>> GetStateList(int id)
        {
            var stateList = await _applicant.GetStates(id);
            var items = stateList.ToList().Select(x => new { Name = x.Name, Id = x.Id, CountryId = x.Country.Country_Id });
            var stateLists = new List<StateDto>();
            foreach(var item in items)
            {
                stateLists.Add(new StateDto { Id = item.Id, Name = item.Name, CountryId = item.CountryId });
            }

            return stateLists;


        }


        public async Task<ApplicantModel> SaveApplicant(ApplicantDto applicant)
        {

            var applicantModel = await this.MapApplicantDetailModel(applicant);
            var applicantDetail =await  _applicant.SaveApplicant(applicantModel);
            var mapApplicantEdnDetail = await this.MapEducationDetailModel(applicant, applicantDetail.ApplicantId);
            var educationDetails = await _applicant.SaveApplicantEdctnDetails(mapApplicantEdnDetail);
            await _applicant.SaveApplicantStatus(new ReviewModel
            {
                ApplicantsId = applicantDetail.ApplicantId,
                GrantId = applicant.applicationDetail.GrantProgram,
                ApplicationStatus = "Submitted",
                UserId =applicant.applicationDetail.Email

            });
            return applicantDetail;

        }

        public async Task<ApplicantModel> MapApplicantDetailModel(ApplicantDto applicant)
        {

            var applicantDetails = new ApplicantModel();
            if (applicant.applicationDetail != null && applicant.contactDetail != null)
            {
                applicantDetails.FirstName = applicant?.applicationDetail?.FirstName;
                applicantDetails.LastName = applicant?.applicationDetail?.LastName;
                applicantDetails.Email = applicant?.applicationDetail?.Email;
                applicantDetails.DateofBirth = DateTime.Parse(applicant?.applicationDetail?.DateofBirth);
                applicantDetails.Country = applicant.applicationDetail.Country;
                applicantDetails.State = applicant.applicationDetail.State;
                applicantDetails.PhysicallyDisabled = applicant.applicationDetail.PhysicallyDisabled;
                applicantDetails.Address = applicant.contactDetail?.Address;
                applicantDetails.City = applicant.contactDetail?.City;
                applicantDetails.PostalCode = applicant?.contactDetail?.PostalCode;
                applicantDetails.Mobile = applicant?.contactDetail?.Mobile;
                applicantDetails.Phone = applicant?.contactDetail?.Phone;
                applicantDetails.GrantId = applicant.applicationDetail.GrantProgram;



            }

            return applicantDetails;

        }

        public async Task<IEnumerable<ApplicantEducationModel>>MapEducationDetailModel(ApplicantDto applicant,int applicantId)
        {
            var eductionDetails = new List<ApplicantEducationModel>();
            if(applicant.educationDetail !=null)
            {

           
                var education = applicant?.educationDetail?.education;
                if(education !=null && education.Any())
                {
                  
                    foreach (var item in education)
                    {
                        var convertedDate = int.Parse(item?.yearofCompleting);
                        eductionDetails.Add(new ApplicantEducationModel
                        {
                            ApplicantModelApplicantId = applicantId,
                            Country = item?.country,
                            CourseName = item?.courseName,
                            InstitutionName = item?.institutionName,
                            YearofCompletion = convertedDate
                        });

                    }
                }
             
                

            }
            return eductionDetails;
        }

        



    }


}

