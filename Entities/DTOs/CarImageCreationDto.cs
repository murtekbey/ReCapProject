using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;

namespace Entities.DTOs
{
    public class CarImageCreationDto : IDto
    {
        public CarImageCreationDto()
        {
            Date = DateTime.Now;
        }
        public int CarImageId { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
        public DateTime Date { get; set; }
    }
}