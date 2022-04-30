using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Constants;
using RentACarPro.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user).Data ?? new List<OperationClaim>();
            var token = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(token, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(LoginDto userForLoginDto)
        {
            var result = _userService.GetByEmail(userForLoginDto.Email);

            if (!result.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var user = result.Data;

            if (user == null || !HashHelper.VerifyPasswordHash(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.LoginError);
            }

            return new SuccessDataResult<User>(user, Messages.LoginSuccess);
        }

        public IDataResult<User> Register(RegisterDto userForRegisterDto)
        {
            HashHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] salt, out byte[] hash);

            var user = new User
            {
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                Email = userForRegisterDto.Email,
                PasswordSalt = salt,
                PasswordHash = hash,
                Status = true
            };

            var result = _userService.Add(user);

            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            return new SuccessDataResult<User>(user, Messages.RegisterSuccess);
        }
    }
}
