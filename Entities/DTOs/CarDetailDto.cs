using Core.Entities;
using System;
using System.Collections.Generic;
using Entities.Concrete;

namespace Entities.DTOs
{
    public class CarDetailDto: IDto
    {
        public int CarId { get; set; }
        public string BrandName { get; set; }
        public string ColorName { get; set; }
        public int ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public List<CarImage> Image { get; set; }
    }
}
