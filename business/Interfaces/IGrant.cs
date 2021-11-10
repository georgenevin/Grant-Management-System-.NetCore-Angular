using models.Dtos;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
   public  interface IGrant
    {

         Task<GrantDto> AddGrantProgram(GrantDto grantProgram);

        Task<IEnumerable<GrantDto>> GetAllGrants();

        Task<GrantProgramModel> GetGrant(int id);

        Task<GrantDto> DeleteGrant(int id);

        Task<GrantDto> UpdateGrant(GrantDto program);
    }
}
