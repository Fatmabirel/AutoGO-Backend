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
            //UserTest();
            //CustomerTest();
            //RentalTest();
        }

        private static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of cars:");
            foreach (var car in carManager.GetCarDetails().Data)
            {
                Console.WriteLine($"{car.CarId} - {car.CarName}, Brand: {car.BrandName}, Color: {car.ColorName} Price: {car.DailyPrice}");
            }
        }
        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            Console.WriteLine("List of cars:");
            foreach (var car in carManager.GetAll().Data)
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
                Description = "M"
            };

            carManager.Add(newCar);
            Console.WriteLine("\nAdded a new car:");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Update a car
            Car carToUpdate = carManager.GetById(20).Data;

            carToUpdate.Description = "Updated Audi A3";
            carToUpdate.DailyPrice = 275;
            carManager.Update(carToUpdate);

            Console.WriteLine("\nUpdated the first car:");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }

            // Delete a car
            carManager.Delete(carManager.GetById(20).Data);
            Console.WriteLine("\nDeleted the second car:");

            foreach (var car in carManager.GetAll().Data)
            {
                Console.WriteLine($"{car.Id} - {car.Description}, Model Year: {car.ModelYear}, Price: {car.DailyPrice}");
            }
        }
        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());

            Console.WriteLine("List of colors:");
            foreach (var color in colorManager.GetAll().Data)
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

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }

            // Update a color
            Color colorToUpdate = colorManager.GetById(2).Data;

            colorToUpdate.Name = "Deep Blue";
            colorManager.Update(colorToUpdate);
            Console.WriteLine("\nUpdated a color:");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }

            // Delete a color
            colorManager.Delete(colorManager.GetById(3).Data);
            Console.WriteLine("\nDeleted a color:");

            foreach (var color in colorManager.GetAll().Data)
            {
                Console.WriteLine($"{color.Id} - {color.Name}");
            }
        }
        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("List of brands:");
            foreach (var brand in brandManager.GetAll().Data)
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

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }

            // Update a brand
            Brand brandToUpdate = brandManager.GetById(2).Data;

            brandToUpdate.Name = "Updated BMW";
            brandManager.Update(brandToUpdate);
            Console.WriteLine("\nUpdated a brand:");

            foreach (var brand in brandManager.GetAll().Data)
            {
                Console.WriteLine($"{brand.Id} - {brand.Name}");
            }
         
        }
        private static void UserTest()
        {
            UserManager userManager = new UserManager(new EfUserDal());

            Console.WriteLine("List of users:");
            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName}, Email: {user.Email}");
            }

            // Add New User
            User newUser = new User
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Password = "password123"
            };

            userManager.Add(newUser);
            Console.WriteLine("\nAdded a new user:");

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName}, Email: {user.Email}");
            }

            // Update a user
            User userToUpdate = userManager.GetById(1006).Data;

            userToUpdate.FirstName = "Jane";
            userToUpdate.LastName = "Smith";
            userToUpdate.Email = "jane.smith@example.com";
            userManager.Update(userToUpdate);

            Console.WriteLine("\nUpdated a user:");

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName}, Email: {user.Email}");
            }

            // Delete a user
            userManager.Delete(userManager.GetById(1006).Data);
            Console.WriteLine("\nDeleted a user:");

            foreach (var user in userManager.GetAll().Data)
            {
                Console.WriteLine($"{user.Id} - {user.FirstName} {user.LastName}, Email: {user.Email}");
            }
        }
        private static void CustomerTest()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());

            // List of customers
            Console.WriteLine("List of customers:");
            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId} - {customer.CompanyName}");
            }

            // Add New Customer
            Customer newCustomer = new Customer
            {
                UserId = 3,
                CompanyName = "Vodafone"
            };

            customerManager.Add(newCustomer);
            Console.WriteLine("\nAdded a new customer:");

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId} - {customer.CompanyName}");
            }

            // Update a customer
            Customer customerToUpdate = customerManager.GetById(2).Data; // Adjust ID as needed

            if (customerToUpdate != null)
            {
                customerToUpdate.UserId = 3;
                customerToUpdate.CompanyName = "Avon";
                customerManager.Update(customerToUpdate);

                Console.WriteLine("\nUpdated a customer:");

                foreach (var customer in customerManager.GetAll().Data)
                {
                    Console.WriteLine($"{customer.UserId} - {customer.CompanyName}");
                }
            }
            else
            {
                Console.WriteLine("\nCustomer to update not found.");
            }

            // Delete a customer
            customerManager.Delete(customerManager.GetById(4).Data); // Adjust ID as needed
            Console.WriteLine("\nDeleted a customer:");

            foreach (var customer in customerManager.GetAll().Data)
            {
                Console.WriteLine($"{customer.UserId} - {customer.CompanyName}");
            }
        }
        private static void RentalTest()
        {
            // Create an instance of RentalManager with a mock or real implementation of IRentalDal
            RentalManager rentalManager = new RentalManager(new EfRentalDal(),new EfCarDal());

            Console.WriteLine("List of rentals:");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine($"{rental.Id} - CarId: {rental.CarId}, CustomerId: {rental.CustomerId}, RentalDate: {rental.RentDate}, ReturnDate: {rental.ReturnDate}");
            }

            // Add New Rental
            Rental newRental = new Rental
            {
                CarId = 7, // Assuming you have a car with ID 1
                CustomerId = 5, // Assuming you have a customer with ID 2
                RentDate = DateTime.Now
            };

            var addResult = rentalManager.Add(newRental);
            Console.WriteLine("\n" + addResult.Message);

            // List Rentals after Adding
            Console.WriteLine("List of rentals after adding:");
            foreach (var rental in rentalManager.GetAll().Data)
            {
                Console.WriteLine($"{rental.Id} - CarId: {rental.CarId}, CustomerId: {rental.CustomerId}, RentalDate: {rental.RentDate}, ReturnDate: {rental.ReturnDate}");
            }

            
        }

    }
}