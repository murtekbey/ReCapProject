using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class PaymentManager: IPaymentService
    {
        IPaymentDal _paymentDal;

        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Add(Payment payment)
        {
            _paymentDal.Add(payment);
            return new SuccessResult(Messages.PaymentAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Delete(Payment payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult(Messages.PaymentDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Payment>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Payment>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Payment>>(_paymentDal.GetAll(), Messages.PaymentListed);
        }

        [CacheAspect]
        public IDataResult<Payment> GetById(int paymentId)
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<Payment>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Payment>(_paymentDal.Get(b => b.PaymentId == paymentId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PaymentValidator))]
        [CacheRemoveAspect("IPaymentService.Get")]
        public IResult Update(Payment payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult(Messages.PaymentUpdated);
        }
    }
}
