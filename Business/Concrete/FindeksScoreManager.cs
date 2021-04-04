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
            var result = CreateFindeksScore(findeksScore).Data;
            _findeksScoreDal.Add(result);
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

        public IDataResult<FindeksScore> GetByCustomerId(int customerId)
        {
            var findeks = _findeksScoreDal.Get(f => f.CustomerId == customerId);
            if (findeks == null)
            {
                return new ErrorDataResult<FindeksScore>(Messages.FindeksScoreNotFound);
            }
            return new SuccessDataResult<FindeksScore>(findeks);
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
            var result = CreateFindeksScore(findeksScore).Data;
            _findeksScoreDal.Update(result);
            return new SuccessResult(Messages.CreditCardUpdated);
        }

        private IDataResult<FindeksScore> CreateFindeksScore(FindeksScore findeks)
        {
            findeks.Score = new Random().Next(0, 1900);

            return new SuccessDataResult<FindeksScore>(findeks);
        }
    }
}
