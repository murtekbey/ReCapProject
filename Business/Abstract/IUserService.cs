using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        User GetById(int userId);
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        IDataResult<UserDetailDto> GetUserDetailByEmail(string email);
    }
}
