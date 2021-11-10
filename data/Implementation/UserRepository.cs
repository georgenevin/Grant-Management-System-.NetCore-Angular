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

   
    public class UserRepository : IUserRepository
    {
        private DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUserModel> AddUser(AppUserModel user)
        {
           _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> IsUserExist(string email)
        {
            return await _context.Users.AnyAsync(x => x.UserName == email);
        }


        public async Task<AppUserModel>GetUser(string username)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }
    }
}
