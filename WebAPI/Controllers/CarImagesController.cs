using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImageService _carImageService;
        private IMapper _mapper;
        public static IWebHostEnvironment _webHostEnvironment;

        public CarImagesController(ICarImageService carImageService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _carImageService = carImageService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            var result = _carImageService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add([FromForm]CarImageCreationDto carImageCreationDto)
        {
            var file = carImageCreationDto.File;
            var carId = carImageCreationDto.CarId;
            if (file == null || carId == null)
            {
                return BadRequest("Incorrect Data");
            }   

            string newFileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string path = _webHostEnvironment.WebRootPath + "\\images\\";

            carImageCreationDto.ImagePath = path + newFileName;
            var carImage = _mapper.Map<CarImage>(carImageCreationDto);
            var result = _carImageService.Add(carImage);

            if (result.Success)
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = System.IO.File.Create(path + newFileName))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(CarImage carImage)
        {
            var result = _carImageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(CarImage carImage)
        {
            var result = _carImageService.Update(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("photosbycar")]
        public IActionResult GetPhotosByCarId(int carId)
        {
            var result = _carImageService.GetPhotosByCarId(carId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
