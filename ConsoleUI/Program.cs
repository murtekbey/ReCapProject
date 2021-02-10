using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();

            //BrandTest();

            //ColorTest();

            //AddColorTest();

            //DeleteColorTest();

            //UpdateColorTest();

            //CarByModelYearTest();

            CarDtoTest();

        }

        private static void CarByModelYearTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = carManager.GetAllByModelYear(1990, 2020);

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", car.Id, brandManager.GetById(car.BrandId).Data.BrandName, colorManager.GetById(car.ColorId).Data.ColorName, car.ModelYear, car.DailyPrice, car.Description);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();

            if (result.Success)
            {
                foreach (var carDto in result.Data)
                {
                    Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", carDto.Id, carDto.BrandName, carDto.ColorName, carDto.ModelYear, carDto.DailyPrice, carDto.Description);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void UpdateColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Update(new Color { ColorId = 1, ColorName = "Orange" });
        }

        private static void DeleteColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Delete(new Color { ColorId = 1002 });
        }

        private static void AddColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            colorManager.Add(new Color { ColorName = "Purple" });
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            var result = colorManager.GetAll();

            if (result.Success)
            {
                foreach (var color in result.Data)
                {
                    Console.WriteLine(color.ColorName);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var result = brandManager.GetAll();

            if (result.Success)
            {
                foreach (var brand in result.Data)
                {
                    Console.WriteLine(brand.BrandName);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }

        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();

            if (result.Success)
            {
                foreach (var car in result.Data)
                {
                    Console.WriteLine(car.Description);
                }
            } else
            {
                Console.WriteLine(result.Message);
            }

        }
    }
}
