using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IColorDal
    {
        void Add(Color color);
        List<Color> GetAll();
        void Update(Color color);
        void Delete(int id);
        Color GetById(int id);
    }
}
