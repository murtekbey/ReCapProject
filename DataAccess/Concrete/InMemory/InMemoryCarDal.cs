using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> {
                new Car {Id=1,BrandId=1,ColorId=3,ModelYear=2015,DailyPrice=450, Description="güzel araba"},
                new Car {Id=2,BrandId=2,ColorId=4,ModelYear=2010,DailyPrice=500, Description="iyi araba"},
                new Car {Id=3,BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=750, Description="çok güzel araba"},
                new Car {Id=4,BrandId=3,ColorId=1,ModelYear=2008,DailyPrice=150, Description="idare eder"},
                new Car {Id=5,BrandId=1,ColorId=2,ModelYear=2009,DailyPrice=125, Description="normal"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == id);
            _cars.Remove(carToDelete);
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
           return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
