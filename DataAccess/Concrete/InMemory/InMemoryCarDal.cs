using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
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

        public void Add(Car entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car entity)
        {
            throw new NotImplementedException();
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}
