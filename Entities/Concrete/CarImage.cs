using Core.Entities;
using System;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public CarImage()
        {
            Date = DateTime.Now;
            IsMain = false;
        }
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime Date { get; set; }
        public bool IsMain { get; set; }
    }
}
