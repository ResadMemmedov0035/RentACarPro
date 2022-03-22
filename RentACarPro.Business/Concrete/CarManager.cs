using Core.Utilities.Results;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Constants;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using RentACarPro.Entities.DTOs;
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

        public IDataResult<List<Car>> GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll());
        }

        public IDataResult<List<Car>> GetAllCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails());
        }

        public IDataResult<Car?> GetCarById(int id)
        {
            return new SuccessDataResult<Car?>(_carDal.Get(c => c.Id == id));
        }

        public IResult AddCar(Car car)
        {
            try
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.AddSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult UpdateCar(Car car)
        {
            try
            {
                _carDal.Update(car);
                return new SuccessResult(Messages.UpdateSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }

        public IResult DeleteCar(Car car)
        {
            try
            {
                _carDal.Delete(car);
                return new SuccessResult(Messages.DeleteSuccess);
            }
            catch (Exception e)
            {
                return new ErrorResult(e.Message);
            }
        }
    }
}
