using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [TransactionScopeAspect]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(IsCarCanBeRented(rental));

            if (result != null)
            {
                return result;
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        //[SecuredOperation("admin")]
        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }


        //[SecuredOperation("admin")]
        [CacheRemoveAspect("IRentalService.Get")]
        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        //[SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        //[SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<Rental> GetById(int rentalId)
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.RentalId == rentalId));
        }

        [CacheAspect]
        public IDataResult<List<Rental>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(rental => rental.CarId == carId));
        }

        [CacheRemoveAspect("IRentalService.Get")]
        public IResult DeliverCar(Rental rental)
        {
            var result = BusinessRules.Run(CheckIfCarAlreadyDelivered(rental.RentalId));
            if (result != null)
            {
                return result;
            }

            Rental updatedCar = _rentalDal.Get(x => x.RentalId == rental.RentalId);
            updatedCar.ReturnDate = rental.ReturnDate;
            _rentalDal.Update(updatedCar);
            return new SuccessResult(Messages.CarDelivered);
        }

        //[SecuredOperation("user,admin")]
        [CacheAspect]
        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<List<RentalDetailDto>> GetUndeliveredRentalDetails()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate == null));
        }

        public IDataResult<List<RentalDetailDto>> GetDeliveredRentalDetails()
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(r => r.ReturnDate != null));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetailsByRentalId(int rentalId)
        {
            if (DateTime.Now.Hour == 8)
            {
                return new ErrorDataResult<List<RentalDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(m => m.RentalId == rentalId));
        }

        //Business Rules
        private IResult IsCarCanBeRented(Rental rental)
        {
            var result = GetByCarId(rental.CarId).Data.LastOrDefault();
            if (result != null)
            {
                if (rental.RentDate >= result.RentDate && rental.RentDate <= result.ReturnDate)
                {
                    return new ErrorResult("Bu tarihler arasında araç daha önce kiralanmış");
                }
                if (rental.RentDate > rental.ReturnDate)
                {
                    return new ErrorResult("Kiralama tarihi dönüş tarihinden büyük olamaz");
                }
            }
            return new SuccessResult();
        }

        private IResult CheckIfCarAlreadyDelivered(int rentalId)
        {
            if (_rentalDal.Get(x => x.RentalId == rentalId && x.ReturnDate == null) == null)
                return new ErrorResult(Messages.CarAlreadyDelivered);
            return new SuccessResult();
        }
    }
}
