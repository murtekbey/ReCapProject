using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager: ICarService
    {
        ICarDal _carDal;
        ICarDtoDal _carDtoDal;
        IBrandDal _brandDal;
        IColorDal _colorDal;

        public CarManager(ICarDal carDal, ICarDtoDal carDtoDal, IBrandDal brandDal, IColorDal colorDal)
        {
            _carDal = carDal;
            _carDtoDal = carDtoDal;
            _brandDal = brandDal;
            _colorDal = colorDal;
        }

        public void Add(Car car) 
        {
            _carDal.Add(car);
            Console.WriteLine("{0} id numaralı araç eklendi.", car.Id);
        }

        public void Delete(int id)
        {
            _carDal.Delete(id);
            Console.WriteLine("{0} id numaralı araç silindi.", id);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public Car GetById(int id)
        {
            return _carDal.GetById(id);
        }

        public List<CarDto> GetCarDetails()
        {
            return _carDtoDal.GetCarDetails(_carDal, _brandDal, _colorDal);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("{0} id numaralı araç bilgileri güncellendi.", car.Id);
        }
            
            
            

    }
}
