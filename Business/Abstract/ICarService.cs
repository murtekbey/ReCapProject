using Entities.Concrete;
using Entities.DTOs;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarService
    {
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
        Car GetById(int carId);
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int brandId);
        List<Car> GetAllByColorId(int colorId);
        List<Car> GetAllByModelYear(int min, int max);
        List<CarDetailDto> GetCarDetails();
    }
}
