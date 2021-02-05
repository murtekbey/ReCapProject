using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IBrandService
    {
        void Add(Brand brand);
        void Update(Brand car);
        void Delete(Brand brand);
        List<Brand> GetAll();
        Brand GetById(int id);
    }
}
