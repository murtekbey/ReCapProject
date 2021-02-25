using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckIfCountOfCarImagesCorrect(carImage.CarId),
                CheckIfFileExtensionCorrect(carImage.ImagePath)
                );

            if (result != null)
            {
                return result;
            }
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            _carImageDal.Delete(carImage);
            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<CarImage>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<CarImage> GetById(int carImageId)
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<CarImage>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == carImageId));
        }

        public IDataResult<List<CarImage>> GetPhotosByCarId(int carId)
        {
            IDataResult<List<CarImage>> result = (IDataResult<List<CarImage>>)BusinessRules.Run(CheckIfPhotosExistsForCar(carId));
            if (result != null)
            {
                return result;
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == carId));
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Update(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfCountOfCarImagesCorrect(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            _carImageDal.Update(carImage);
            return new SuccessResult(Messages.CarImageUpdated);
        }

        private IResult CheckIfCountOfCarImagesCorrect(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult(Messages.CountOfCarImagesCorrect);
            }
            return new SuccessResult();
        }

        private IDataResult<List<CarImage>> CheckIfPhotosExistsForCar(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new ErrorDataResult<List<CarImage>>(new List<CarImage> 
                { new CarImage {ImagePath = "../WebAPI/wwwroot/images/logo.png"} }
                ); 
            }
            return new SuccessDataResult<List<CarImage>>();
        }

        private IResult CheckIfFileExtensionCorrect(string imagePath)
        {
            switch (Path.GetExtension(imagePath).ToLower())
            {
                case ".jpg":
                    return new SuccessResult();
                case ".jpeg":
                    return new SuccessResult();
                case ".png":
                    return new SuccessResult();
                default:
                    return new ErrorResult(Messages.IncorrectFileExtension);
            }
        }
    }
}
