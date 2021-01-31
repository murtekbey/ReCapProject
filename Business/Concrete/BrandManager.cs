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

        public void Add(Brand brand) => _brandDal.Add(brand);

        public void Delete(int id) => _brandDal.Delete(id);

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id) => _brandDal.GetById(id);

        public void Update(Brand brand) => _brandDal.Update(brand);
    }
}
