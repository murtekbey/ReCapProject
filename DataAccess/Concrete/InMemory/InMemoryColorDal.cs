using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryColorDal : IColorDal
    {
        List<Color> _colors;

        public InMemoryColorDal()
        {
            _colors = new List<Color> {
                new Color {ColorId=1,ColorName="Black"},
                new Color {ColorId=2,ColorName="White"},
                new Color {ColorId=3,ColorName="Red"},
                new Color {ColorId=4,ColorName="Blue"},
                new Color {ColorId=5,ColorName="Yellow"}
            };
        }
        public void Add(Color color)
        {
            _colors.Add(color);
        }

        public void Delete(int id)
        {
            Color colorToDelete = _colors.SingleOrDefault(c => c.ColorId == id);
            _colors.Remove(colorToDelete);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }

        public Color GetById(int id)
        {
            return _colors.SingleOrDefault(c => c.ColorId == id);
        }

        public void Update(Color color)
        {
            Color colorToUpdate = _colors.SingleOrDefault(b => b.ColorId == color.ColorId);
            colorToUpdate.ColorName = color.ColorName;
        }
    }
}
