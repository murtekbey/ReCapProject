using Core.Entities;
using System;

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

        public DateTime CarImageDate { get; set; }
        public string ImagePath { get; set; }
    }
}
