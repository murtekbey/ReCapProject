using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car) => _carDal.Add(car);

        public void Delete(int id) => _carDal.Delete(id);

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id) => _carDal.GetById(id);

        public void Update(Car car) => _carDal.Update(car);

        public bool GetCarsByBrandId(List<Car> lists)
        {
            throw new NotImplementedException();
        }
    }
}
