using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());

            // AddSomeData(carManager, brandManager, colorManager);

            // carManager.Delete(new Car { Id = 1 });

            Car updatedCar = new Car { Id = 2, BrandId = 1, ColorId = 5, DailyPrice = 750, Description = "güncel araba", ModelYear = 2020 };

            // carManager.Update(updatedCar);

            Console.WriteLine("---------------- CAR LIST ----------------");
            foreach (var item in carManager.GetAll())
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", item.Id, brandManager.GetById(item.BrandId).BrandName, colorManager.GetById(item.ColorId).ColorName, item.ModelYear, item.DailyPrice, item.Description);
            }

            Console.WriteLine("\n---------------- CAR BY BRAND ID ----------------");
            foreach (var item in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", item.Id, brandManager.GetById(item.BrandId).BrandName, colorManager.GetById(item.ColorId).ColorName, item.ModelYear, item.DailyPrice, item.Description);
            }

            Console.WriteLine("\n---------------- CAR BY COLOR ID ----------------");
            foreach (var item in carManager.GetAllByColorId(1))
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", item.Id, brandManager.GetById(item.BrandId).BrandName, colorManager.GetById(item.ColorId).ColorName, item.ModelYear, item.DailyPrice, item.Description);
            }

            Console.WriteLine("\n---------------- CAR BY MODEL YEAR (min, max) ----------------");
            foreach (var item in carManager.GetAllByModelYear(2000,2020))
            {
                Console.WriteLine("{0} - {1} - {2} - {3} - {4} - {5}", item.Id, brandManager.GetById(item.BrandId).BrandName, colorManager.GetById(item.ColorId).ColorName, item.ModelYear, item.DailyPrice, item.Description);
            }

        }

        private static void AddSomeData(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            List<Brand> brandList = new List<Brand> { // Let's add some brands
                new Brand {BrandName="Alfa Romeo"},
                new Brand {BrandName="Aston Martin"},
                new Brand {BrandName="Audi"},
                new Brand {BrandName="Bentley"},
                new Brand {BrandName="BMW"}
            };

            List<Color> colorList = new List<Color> { // and some colors
                new Color {ColorName="Black"},
                new Color {ColorName="White"},
                new Color {ColorName="Red"},
                new Color {ColorName="Blue"},
                new Color {ColorName="Yellow"}
            };

            List<Car> carList = new List<Car> { // now some cars
                new Car {BrandId=1,ColorId=3,ModelYear=2015,DailyPrice=450, Description="güzel araba"},
                new Car {BrandId=2,ColorId=4,ModelYear=2010,DailyPrice=500, Description="iyi araba"},
                new Car {BrandId=2,ColorId=1,ModelYear=2020,DailyPrice=750, Description="çok güzel araba"},
                new Car {BrandId=3,ColorId=1,ModelYear=2008,DailyPrice=150, Description="idare eder"},
                new Car {BrandId=1,ColorId=2,ModelYear=2009,DailyPrice=125, Description="normal"}
            };

            foreach (Brand brand in brandList)
            {
                brandManager.Add(brand);
            }

            foreach (Color color in colorList)
            {
                colorManager.Add(color);
            }

            foreach (Car car in carList)
            {
                carManager.Add(car);
            }

        }
    }
}
