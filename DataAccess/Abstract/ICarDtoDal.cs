using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDtoDal
    {
        List<CarDto> GetCarDetails(ICarDal carDal, IBrandDal brandDal, IColorDal colorDal);
    }
}
