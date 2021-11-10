using data.Data;
using data.Interfaces;
using Microsoft.EntityFrameworkCore;
using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Implementation
{
    public class GrantRepository : IGrantRepository
    {

        private DataContext _context;

        public GrantRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<GrantProgramModel> SaveGrants(GrantProgramModel grantProgram)
        {
            _context.GrantPrograms.Add(grantProgram);
            await _context.SaveChangesAsync();
            return grantProgram;
        }

        public async Task<IEnumerable<GrantProgramModel>>GetAllGrants()
        {
           
          return  await _context.GrantPrograms.ToListAsync();
        }

        public async Task<GrantProgramModel> GetGrant(int id)
        {
            return await _context.GrantPrograms.FindAsync(id);
        }

        public async Task<GrantProgramModel> DeleteGrant(GrantProgramModel grant)
        {

           
          
            _context.GrantPrograms.Remove(grant);
            await _context.SaveChangesAsync();
            return grant;

        }

        public async Task<GrantProgramModel>UpdateGrant(GrantProgramModel grant)
        {
            _context.GrantPrograms.Update(grant);
            await _context.SaveChangesAsync();
            return grant;
        }
    }
}
