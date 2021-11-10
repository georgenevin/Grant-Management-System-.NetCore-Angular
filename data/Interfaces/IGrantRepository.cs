using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces
{
    public interface IGrantRepository
    {
        Task<GrantProgramModel> SaveGrants(GrantProgramModel grantProgramModel);

        Task<IEnumerable<GrantProgramModel>> GetAllGrants();

         Task<GrantProgramModel> GetGrant(int id);

        Task<GrantProgramModel> DeleteGrant(GrantProgramModel grant);

        Task<GrantProgramModel> UpdateGrant(GrantProgramModel grant);
    }
}
