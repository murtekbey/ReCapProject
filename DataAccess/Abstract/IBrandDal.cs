using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IBrandDal
    {
        void Add(Brand brand);
        List<Brand> GetAll();
        void Update(Brand brand);
        void Delete(int id);
        Brand GetById(int id);
    }
}
