using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        List<Brand> GetAll();
        void Update(Brand car);
        void Delete(int id);
        Brand GetById(int id);
    }
}
