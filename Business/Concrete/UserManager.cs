using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public void Delete(User user)
        {
            _userDal.Delete(user);
        }

        public User GetById(int userId)
        {
            return _userDal.Get(u => u.UserId == userId);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<UserDetailDto> GetUserDetailByEmail(string userEmail)
        {
            var result = _userDal.Get(u => u.Email == userEmail);
            return new SuccessDataResult<UserDetailDto>(_userDal.GetUserDetails(u => u.UserId == result.UserId));
        }

        public void Update(User user)
        {
            _userDal.Update(user);
        }
    }
}
