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
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of cars:");
            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Add New Car
            Car newCar = new Car
            {
                Id = 11,
                BrandId = 3,
                ColorId = 2,
                ModelYear = 2022,
                DailyPrice = 500,
                Description = "New Mercedes-Benz E-Class"
            };

            carManager.Add(newCar);
            Console.WriteLine("\nAdded a new car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Update a car
            Car carToUpdate = carManager.GetById(1);

            carToUpdate.Description = "Updated Audi A4";
            carToUpdate.DailyPrice = 275;
            carManager.Update(carToUpdate);
            Console.WriteLine("\nUpdated the first car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Delete a car
            carManager.Delete(carManager.GetById(2));
            Console.WriteLine("\nDeleted the second car:");

            foreach (var car in carManager.GetAll())
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }
        }
    }
}