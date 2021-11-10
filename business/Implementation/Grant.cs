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
   public class Grant: IGrant
    {
        private readonly IGrantRepository _igrantrepository;
        private readonly IMapper _mapper;

        public Grant(IGrantRepository grantRepository,IMapper mapper)
        {
            _igrantrepository = grantRepository;
            _mapper = mapper;
        }

        public async Task<GrantDto> AddGrantProgram(GrantDto grantProgram)
        {
            var grantData = _mapper.Map<GrantProgramModel>(grantProgram);
            var grant = await _igrantrepository.SaveGrants(grantData);
            var grantReturned = _mapper.Map<GrantDto>(grant);
      
            return grantReturned;
        }

        public async Task<IEnumerable<GrantDto>> GetAllGrants()
        {
            var programs=  await _igrantrepository.GetAllGrants();
     
           
            return _mapper.Map<IEnumerable<GrantDto>>(programs);

        }

        public async Task<GrantProgramModel> GetGrant(int id)
        {
            var program = await _igrantrepository.GetGrant(id);
            return program;
        }


        public async Task<GrantDto>DeleteGrant(int id)
        {
            var grantToDelete = await this.GetGrant(id);
            var deletedGrant = await _igrantrepository.DeleteGrant(grantToDelete);
            return _mapper.Map<GrantDto>(deletedGrant);
        }

       public async Task<GrantDto>UpdateGrant(GrantDto program)
        {
            var gantToUpdate= _mapper.Map<GrantProgramModel>(program);
            var updatedGrant = await _igrantrepository.UpdateGrant(gantToUpdate);
            return _mapper.Map<GrantDto>(updatedGrant);
        }

       
    }
}
