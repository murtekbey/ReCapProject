using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class FindeksScoreManager : IFindeksScoreService
    {
        IFindeksScoreDal _findeksScoreDal;

        public FindeksScoreManager(IFindeksScoreDal findeksScoreDal)
        {
            _findeksScoreDal = findeksScoreDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(FindeksScoreValidator))]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Add(FindeksScore findeksScore)
        {
            _findeksScoreDal.Add(findeksScore);
            return new SuccessResult(Messages.FindeksScoreAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Delete(FindeksScore findeksScore)
        {
            _findeksScoreDal.Delete(findeksScore);
            return new SuccessResult(Messages.FindeksScoreDeleted);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<List<FindeksScore>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<FindeksScore>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<FindeksScore>>(_findeksScoreDal.GetAll(), Messages.FindeksScoreListed);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<FindeksScore> GetById(int findeksScoreId)
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<FindeksScore>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<FindeksScore>(_findeksScoreDal.Get(b => b.FindeksScoreId == findeksScoreId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("IFindeksScoreService.Get")]
        public IResult Update(FindeksScore findeksScore)
        {
            _findeksScoreDal.Update(findeksScore);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
