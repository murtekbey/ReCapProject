using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ICustomerService _customerService;
        IFindeksScoreService _findeksScoreService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, ICustomerService customerService, IFindeksScoreService findeksScoreService)
        {
            _userService = userService;
            _customerService = customerService;
            _tokenHelper = tokenHelper;
            _findeksScoreService = findeksScoreService;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IResult IsAuthenticated(string userMail, List<string> requiredRoles)
        {
            if (requiredRoles != null)
            {
                var user = _userService.GetByMail(userMail);
                var claims = _userService.GetClaims(user);
                var result = requiredRoles.All(role => claims.Select(u => u.Name).Contains(role));
                if (!result)
                {
                    return new ErrorResult(Messages.AuthorizationDenied);
                }
            }

            return new SuccessResult();
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck==null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password,userToCheck.PasswordHash,userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfullLogin);
        }

        [TransactionScopeAspect]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);

            var getUserId = _userService.GetByMail(userForRegisterDto.Email).UserId;
            var customer = new Customer
            {
                UserId = getUserId,
                CompanyName = userForRegisterDto.CompanyName
            };
            _customerService.Add(customer);

            var getCustomerId = _customerService.GetByCompanyName(userForRegisterDto.CompanyName).Data.CustomerId;
            var findeks = new FindeksScore
            {
                CustomerId = getCustomerId,
            };
            _findeksScoreService.Add(findeks);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }

        [TransactionScopeAspect]
        public IResult UserDetailUpdate(UserDetailForUpdate userDetailForUpdate)
        {
            var user = _userService.GetById(userDetailForUpdate.UserId);
            var customer = _customerService.GetById(userDetailForUpdate.CustomerId).Data;

            if (!HashingHelper.VerifyPasswordHash(userDetailForUpdate.CurrentPassword, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorResult(Messages.PasswordError);
            }

            if (!string.IsNullOrEmpty(userDetailForUpdate.NewPassword))
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(userDetailForUpdate.NewPassword, out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }
            user.FirstName = userDetailForUpdate.FirstName;
            user.LastName = userDetailForUpdate.LastName;
            customer.CompanyName = userDetailForUpdate.CompanyName;
            _userService.Update(user);
            _customerService.Update(customer);

            return new SuccessResult(Messages.UserUpdated);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email)!=null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }
    }
}
