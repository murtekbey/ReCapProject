using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(CarImageCreationDto carImageCreationDto);
        IResult Update(CarImageCreationDto carImageCreationDto);
        IResult Delete(CarImageCreationDto carImageCreationDto);
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> GetById(int carImageId);
        IDataResult<List<CarImage>> GetPhotosByCarId(int carId);
    }
}
