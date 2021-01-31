using Business.Concrete;
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
            CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            Car newCar = new Car { Id = 6, BrandId = 4, ColorId = 5, DailyPrice = 495, Description = "hoş araba", ModelYear = 2015 };
            Car updatedCar = new Car { Id = 4, BrandId = 1, ColorId = 5, DailyPrice = 750, Description = "güncel araba", ModelYear = 2020 };
            carManager.Add(newCar);
            carManager.Delete(3);
            carManager.Update(updatedCar);


            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine("ID: {0}\nBrand ID: {1}\nColor ID: {2}\nDaily Price: {3}\nDescription: {4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
                Console.WriteLine("---------------------------------------------------------------");
            }

            Console.WriteLine(carManager.GetById(1).Description);
            Console.WriteLine("--------------------------------");

            GetCarDetails(carManager, brandManager, colorManager);
        }

        private static void GetCarDetails(CarManager carManager, BrandManager brandManager, ColorManager colorManager)
        {
            var result = from c in carManager.GetAll()
                         join b in brandManager.GetAll()
                         on c.BrandId equals b.BrandId
                         join co in colorManager.GetAll()
                         on c.ColorId equals co.ColorId
                         orderby c.DailyPrice descending
                         select (c.Id, b.BrandName, co.ColorName, c.DailyPrice, c.Description);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}
