using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal
    {
        void Add(Car car);
        List<Car> GetAll();
        void Update(Car car);
        void Delete(int id);
        Car GetById(int id);
    }
}
