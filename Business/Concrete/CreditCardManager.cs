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
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Add(CreditCard creditCard)
        {
            _creditCardDal.Add(creditCard);
            return new SuccessResult(Messages.CreditCardAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Delete(CreditCard creditCard)
        {
            _creditCardDal.Delete(creditCard);
            return new SuccessResult(Messages.CreditCardDeleted);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<List<CreditCard>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<CreditCard>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(), Messages.CreditCardListed);
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<CreditCard> GetById(int creditCardId)
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<CreditCard>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(b => b.CreditCardId == creditCardId));
        }

        [SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<CreditCard> GetByUserId(int userId)
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<CreditCard>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(b => b.UserId == userId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CreditCardValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        public IResult Update(CreditCard creditCard)
        {
            _creditCardDal.Update(creditCard);
            return new SuccessResult(Messages.CreditCardUpdated);
        }
    }
}
