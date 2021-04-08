using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager: IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new SuccessResult(Messages.ColorAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.ColorDeleted);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorListed);
        }

        [CacheAspect]
        public IDataResult<Color> GetById(int colorId)
        {
            if (DateTime.Now.Hour == 6)
            {
                return new ErrorDataResult<Color>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
