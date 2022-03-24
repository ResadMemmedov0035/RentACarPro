using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using RentACarPro.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        private readonly List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, DailyPrice = 30000, Description = "Mercedes-Benz, 4 goz", ModelYear = 2004 },
                new Car { Id = 2, BrandId = 1, ColorId = 2, DailyPrice = 60000, Description = "Mercedes-Benz, bahali", ModelYear = 2017 },
                new Car { Id = 3, BrandId = 1, ColorId = 4, DailyPrice = 20000, Description = "Toyota, normal", ModelYear = 2005 },
            };
        }

        public Car? Get(Expression<Func<Car, bool>> filter)
        {
            return _cars.SingleOrDefault(filter.Compile());
        }

        public List<Car> GetAll(Expression<Func<Car, bool>>? filter = null)
        {
            if (filter != null)
            {
                return _cars.Where(filter.Compile()).ToList();
            }
            return _cars;
        }

        public void Add(Car car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(nameof(car));
            }
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var itemToDelete = _cars.Single(c => c.Id == car.Id);
            _cars.Remove(itemToDelete);
        }
      
        public void Update(Car car)
        {
            var itemToUpdate = _cars.Single(c => c.Id == car.Id);
            itemToUpdate.BrandId = car.BrandId;
            itemToUpdate.ColorId = car.ColorId;
            itemToUpdate.ModelYear = car.ModelYear;
            itemToUpdate.DailyPrice = car.DailyPrice;
            itemToUpdate.Description = car.Description;
        }

        public List<CarDetailDto> GetAllCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }
    }
}
