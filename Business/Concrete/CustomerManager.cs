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

namespace Business.Concrete
{
    public class CustomerManager: ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Add(Customer customer)
        {
            if (GetByCompanyName(customer.CompanyName).Data != null) {
                return new ErrorResult(Messages.CompanyNameInvalid);
            }
            _customerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Customer>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Customer>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CustomerListed);
        }

        [CacheAspect]
        public IDataResult<Customer> GetByCompanyName(string companyName)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.CompanyName == companyName));
        }

        [CacheAspect]
        public IDataResult<Customer> GetById(int customerId)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<Customer>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Customer>(_customerDal.Get(b => b.CustomerId == customerId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
