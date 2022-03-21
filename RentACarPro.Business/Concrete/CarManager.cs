using RentACarPro.Business.Abstract;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void AddCar(Car car)
        {
            //business rules...
            _carDal.Add(car);
        }

        public void UpdateCar(Car car)
        {
            //business rules
            _carDal.Update(car);
        }

        public void DeleteCar(Car car)
        {
            //business rules...
            _carDal.Delete(car);
        }

        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetAllCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        public Car? GetCarById(int id)
        {
            return _carDal.Get(c => c.Id == id);
        }
    }
}
