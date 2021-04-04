using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IFindeksScoreService
    {
        IResult Add(FindeksScore findeksScore);
        IResult Update(FindeksScore findeksScore);
        IResult Delete(FindeksScore findeksScore);
        IDataResult<List<FindeksScore>> GetAll();
        IDataResult<FindeksScore> GetById(int findeksScoreId);
        IDataResult<FindeksScore> GetByCustomerId(int customerId);
    }
}
