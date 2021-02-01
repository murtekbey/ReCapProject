using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        List<Car> GetAll();
        void Update(Car car);
        void Delete(int id);
        Car GetById(int id);
        List<CarDto> GetCarDetails();
    }
}
