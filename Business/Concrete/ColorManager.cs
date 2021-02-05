using Business.Abstract;
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

        public void Add(Color color)
        {
            if (color.ColorName.Length > 2)
            {
                _colorDal.Add(color);
                Console.WriteLine("{0} isimli renk başarılı bir şekilde eklendi.", color.ColorName);
            }
            else
            {
                Console.WriteLine("Girdiğiniz renk ismi 2 karakterden büyük olmalıdır.");
            }

        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
            Console.WriteLine("{0} isimli renk başarılı bir şekilde silindi.", color.ColorName);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public Color GetById(int id)
        {
            return _colorDal.Get(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
            Console.WriteLine("{0} isimli renk başarılı bir şekilde güncellendi.", color.ColorName);
        }
    }
}
