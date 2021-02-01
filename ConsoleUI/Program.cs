using Business.Concrete;
using DataAccess.Abstract;
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
            CarManager carManager = new CarManager(new InMemoryCarDal(), new InMemoryCarDtoDal(), new InMemoryBrandDal(), new InMemoryColorDal());
            BrandManager brandManager = new BrandManager(new InMemoryBrandDal());
            ColorManager colorManager = new ColorManager(new InMemoryColorDal());

            Car newCar = new Car { Id = 6, BrandId = 4, ColorId = 5, DailyPrice = 495, Description = "hoş araba", ModelYear = 2015 };
            Car updatedCar = new Car { Id = 4, BrandId = 1, ColorId = 5, DailyPrice = 750, Description = "güncel araba", ModelYear = 2020 };

            // Add Car
            carManager.Add(newCar);
            Console.WriteLine("--------------------------------");


            // Delete Car
            carManager.Delete(3);
            Console.WriteLine("--------------------------------");


            // Update Car
            carManager.Update(updatedCar);
            Console.WriteLine("--------------------------------");


            // Get All Cars
            Console.WriteLine("-------- CAR LIST ---------");
            foreach (var car in carManager.GetAll()) 
            {
                Console.WriteLine("ID: {0}\nBrand ID: {1}\nColor ID: {2}\nDaily Price: {3}\nDescription: {4}", car.Id, car.BrandId, car.ColorId, car.DailyPrice, car.Description);
                Console.WriteLine("--------------------------------");
            }


            // Get Car Description By Id
            Console.WriteLine("-------- CAR BY ID ---------");
            var carById = carManager.GetById(1);
            Console.WriteLine("ID: {0}\nBrand ID: {1}\nColor ID: {2}\nDaily Price: {3}\nDescription: {4}", carById.Id, carById.BrandId, carById.ColorId, carById.DailyPrice, carById.Description); 
            Console.WriteLine("--------------------------------");


            // Get Car Details
            Console.WriteLine("-------- CAR DETAILS ---------");
            foreach (var item in carManager.GetCarDetails()) 
            {
                Console.WriteLine("ID: {0}\nBrand Name: {1}\nColor Name: {2}\nDaily Price: {3}\nDescription: {4}", item.CarId, item.BrandName, item.ColorName, item.DailyPrice, item.Description);
                Console.WriteLine("--------------------------------");
            }
            
        }
    }
}
