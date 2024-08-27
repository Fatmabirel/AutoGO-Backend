using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, ModelYear = 2018, DailyPrice = 250, Description = "Audi A4" },
                new Car { Id = 2, BrandId = 2, ColorId = 2, ModelYear = 2019, DailyPrice = 300, Description = "BMW 3 Series" },
                new Car { Id = 3, BrandId = 3, ColorId = 3, ModelYear = 2020, DailyPrice = 350, Description = "Mercedes-Benz C-Class" },
                new Car { Id = 4, BrandId = 4, ColorId = 4, ModelYear = 2017, DailyPrice = 220, Description = "Volkswagen Golf" },
                new Car { Id = 5, BrandId = 5, ColorId = 5, ModelYear = 2021, DailyPrice = 400, Description = "Tesla Model 3" },
                new Car { Id = 6, BrandId = 1, ColorId = 2, ModelYear = 2020, DailyPrice = 320, Description = "Audi Q5" },
                new Car { Id = 7, BrandId = 2, ColorId = 3, ModelYear = 2018, DailyPrice = 280, Description = "BMW X5" },
                new Car { Id = 8, BrandId = 3, ColorId = 4, ModelYear = 2019, DailyPrice = 330, Description = "Mercedes-Benz GLC" },
                new Car { Id = 9, BrandId = 4, ColorId = 5, ModelYear = 2017, DailyPrice = 210, Description = "Volkswagen Passat" },
                new Car { Id = 10, BrandId = 5, ColorId = 1, ModelYear = 2021, DailyPrice = 450, Description = "Tesla Model S" }
            };
        }


        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (carToDelete != null)
            {
                _cars.Remove(carToDelete);
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
           return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.SingleOrDefault(c => c.Id == id);
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);
            if (carToUpdate != null)
            {
                carToUpdate.BrandId = car.BrandId;
                carToUpdate.ColorId = car.ColorId;
                carToUpdate.ModelYear = car.ModelYear;
                carToUpdate.DailyPrice = car.DailyPrice;
                carToUpdate.Description = car.Description;
            }
        }

    }
}
