using data.Dtos;
using models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace business.Interfaces
{
   public interface IUser
    {

            Task<bool> IsUserExist(string email);

            Task<UserDto> AddUser(RegisterDto user);

             Task<UserDto> GetUser(string userName);

        Task<LoggedApplicantDto> GetLoggedApplicant(string userName);
    }
}
