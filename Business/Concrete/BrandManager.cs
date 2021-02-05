using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager: IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length > 2)
            {
                _brandDal.Add(brand);
                Console.WriteLine("{0} isimli marka başarılı bir şekilde eklendi.", brand.BrandName);
            }
            else
            {
                Console.WriteLine("Marka isminiz 2 karakterden büyük olmalıdır.");
            }

        }

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            Console.WriteLine("{0} isimli marka başarılı bir şekilde silindi.", brand.BrandName);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
            Console.WriteLine("{0} isimli marka başarılı bir şekilde güncellendi.", brand.BrandName);
        }
    }
}
