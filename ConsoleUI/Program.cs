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

            //CarDtoTest();

        }

        private static void CarByModelYearTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var car in carManager.GetAllByModelYear(1990, 2020))
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", car.Id, brandManager.GetById(car.BrandId).BrandName, colorManager.GetById(car.ColorId).ColorName, car.ModelYear, car.DailyPrice, car.Description);
            }
        }

        private static void CarDtoTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var carDto in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", carDto.Id, carDto.BrandName, carDto.ColorName, carDto.ModelYear, carDto.DailyPrice, carDto.Description);
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

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine(color.ColorName);
            }
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine(brand.BrandName);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine(car.Description);
            }
        }
    }
}
