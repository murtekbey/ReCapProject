using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            var rentalCar = _rentalDal.Get(r => r.CarId == rental.CarId);

            if (rentalCar != null && rentalCar.ReturnDate == DateTime.MinValue)
            {
                return new ErrorResult(Messages.NoReturnDate);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IResult DeliverCar(int rentalId)
        {
            var rentalCar = _rentalDal.Get(b => b.Id == rentalId);

            if (rentalCar.ReturnDate != DateTime.MinValue)
            {
                return new ErrorResult(Messages.CarDeliveredBefore);
            }
            _rentalDal.Update(new Rental
            {
                Id = rentalCar.Id,
                CarId = rentalCar.Id,
                CustomerId = rentalCar.CustomerId,
                RentDate = rentalCar.RentDate,
                ReturnDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"))
            });

            return new SuccessResult(Messages.CarDelivered);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Rental>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int id)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<Rental>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Rental>(_rentalDal.Get(b => b.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }
    }
}
