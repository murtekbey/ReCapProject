using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal()
        {
            _brands = new List<Brand> {
                new Brand {BrandId=1,BrandName="Alfa Romeo"},
                new Brand {BrandId=2,BrandName="Aston Martin"},
                new Brand {BrandId=3,BrandName="Audi"},
                new Brand {BrandId=4,BrandName="Bentley"},
                new Brand {BrandId=5,BrandName="BMW"}
            };
        }
        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(int id)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == id);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int id)
        {
            return _brands.SingleOrDefault(b => b.BrandId == id);
        }

        public void Update(Brand brand)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);
            brandToUpdate.BrandName = brand.BrandName;
        }
    }
}
