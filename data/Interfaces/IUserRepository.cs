using models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Interfaces
{
   public interface IUserRepository
    {
        public Task<bool> IsUserExist(string email);

        public Task<AppUserModel> AddUser(AppUserModel userInfo);

        public Task<AppUserModel> GetUser(string username);
       

    }
}
