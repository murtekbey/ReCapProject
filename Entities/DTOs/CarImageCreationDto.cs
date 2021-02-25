﻿using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageCreationDto:IDto
    {
        public CarImageCreationDto()
        {
            Date = DateTime.Now;
        }
        public string CarId { get; set; }
        public string ImagePath { get; set; }
        public IFormFile File { get; set; }
        public DateTime Date { get; set; }
    }
}
