using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //ColorTest();
            //BrandTest();
            //CarDetailsTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of cars:");
            foreach (var car in carManager.GetCarDetails())
            {
                Console.WriteLine($"{car.CarId} - {car.CarName}, Brand: {car.BrandName}, Color: {car.ColorName} Price: {car.DailyPrice}");
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of cars:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Add New Car
            Car newCar = new Car
            {
                BrandId = 3,
                ColorId = 2,
                ModelYear = 2022,
                DailyPrice = 500,
                Description = "New Mercedes-Benz C-Class"
            };

            carManager.Add(newCar);
            Console.WriteLine("\nAdded a new car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Update a car
            Car carToUpdate = carManager.GetById(10);

            carToUpdate.Description = "Updated Audi A2";
            carToUpdate.DailyPrice = 275;
            carManager.Update(carToUpdate);
            Console.WriteLine("\nUpdated the first car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Delete a car
            carManager.Delete(carManager.GetById(10));
            Console.WriteLine("\nDeleted the second car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("List of colors:");
            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }

            // Add New Color
            Color newColor = new Color
            {
                Name = "Crimson Red"
            };

            colorManager.Add(newColor);
            Console.WriteLine("\nAdded a new color:");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }

            // Update a color
            Color colorToUpdate = colorManager.GetById(2);

            colorToUpdate.Name = "Deep Blue";
            colorManager.Update(colorToUpdate);
            Console.WriteLine("\nUpdated a color:");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }

            // Delete a color
            colorManager.Delete(colorManager.GetById(3));
            Console.WriteLine("\nDeleted a color:");

            foreach (var color in colorManager.GetAll())
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("List of brands:");
            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }

            // Add New Brand
            Brand newBrand = new Brand
            {
                Name = "Porsche"
            };

            brandManager.Add(newBrand);
            Console.WriteLine("\nAdded a new brand:");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }

            // Update a brand
            Brand brandToUpdate = brandManager.GetById(2);

            brandToUpdate.Name = "Updated BMW";
            brandManager.Update(brandToUpdate);
            Console.WriteLine("\nUpdated a brand:");

            foreach (var brand in brandManager.GetAll())
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }

         
        }


    }
}