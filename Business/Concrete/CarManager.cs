using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car) 
        {
            if (car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("{0} id numaralı araç eklendi.", car.Id);
            }
            else
            {
                Console.WriteLine("Günlük fiyat tutarı 0'dan büyük olmalıdır.");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("{0} id numaralı araç silindi.", car.Id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetAllByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }

        public List<Car> GetAllByModelYear(int min, int max)
        {
            return _carDal.GetAll(p => p.ModelYear >= min && p.ModelYear <= max);
        }

        public Car GetById(int carId)
        {
            return _carDal.Get(c => c.Id == carId);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            return _carDal.GetCarDetails();
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("{0} id numaralı araç bilgileri güncellendi.", car.Id);
        }
            
            
            

    }
}
