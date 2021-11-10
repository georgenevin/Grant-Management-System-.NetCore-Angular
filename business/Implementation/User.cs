using business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data.Interfaces;
using models.Dtos;
using data.Dtos;
using models.Models;
using AutoMapper;

namespace business.Implementation
{
    public class User : IUser
    {

        public IUserRepository _userRepository { get; set; }

        public ITokenService _token { get; set; }

        public IMapper _mapper { get; set; }

        public User(IUserRepository userRepository, ITokenService tokenService,IMapper mapper)
        {
            _userRepository = userRepository;
            _token = tokenService;
            _mapper = mapper;
        }

        public async Task<bool> IsUserExist(string email)
        {
            return await _userRepository.IsUserExist(email);
        }


        public async Task<UserDto>AddUser(RegisterDto user)
        {

            var newUser = new AppUserModel
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.Email,
                Password = user.Password,
                UserType = "Applicants",
                CreatedDate = DateTime.Now,
                


            };

        var addedUser=  await  _userRepository.AddUser(newUser);

            return new UserDto
            {
                Email = newUser.UserName,
                Password = newUser.Password,
                Token=_token.CreateToken(newUser),
            };



        }


        public async Task<UserDto> GetUser(string userName)
        {
            var user = await _userRepository.GetUser(userName);

            if (user == null)
            {
                return null;
            }
            return new UserDto
            {
                Email = user.UserName,
                Password = user.Password,
                Token = _token.CreateToken(user)
            };
        }


        public async Task<LoggedApplicantDto>GetLoggedApplicant(string userName)
        {
            var user = await _userRepository.GetUser(userName);
            return new LoggedApplicantDto
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.UserName

            };
        }


    }
}
