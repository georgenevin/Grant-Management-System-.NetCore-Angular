using AutoMapper;
using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POC_GMS.Extensions
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<GrantProgramModel,GrantDto>();
            CreateMap<GrantDto,GrantProgramModel>();
            CreateMap<IEnumerable<GrantDto>, IEnumerable<GrantProgramModel>>();
            CreateMap<LoggedApplicantDto, AppUserModel>();
            CreateMap<IEnumerable<StateModel>,IEnumerable<StateDto>>();
            CreateMap<ReviewDto, ReviewModel>();
            CreateMap<ReviewModel, ReviewDto > ();

        }
    }
}
