using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Exceptions;
using Core.Utilities.Results;
using RentACarPro.Business.Abstract;
using RentACarPro.Business.Aspects.Autofac.Authorization;
using RentACarPro.Business.Constants;
using RentACarPro.Business.ValidationRules.FluentValidation;
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

        [CacheAspect]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.AllRecieved);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId), Messages.AllRecieved);
        }

        [CacheAspect]
        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == colorId), Messages.AllRecieved);
        }

        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllDetails()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), Messages.AllRecieved);
        }

        [CacheAspect]
        public IDataResult<Car> GetById(int id)
        {
            try
            {
                return new SuccessDataResult<Car>(_carDal.Get(c => c.Id == id), Messages.ItemRecieved);
            }
            catch (EntityNotFoundException<Car> e)
            {
                return new ErrorDataResult<Car>(e.Message);
            }
        }

        [SecuredOperation("car.add")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Car car)
        {
            _carDal.Add(car);
            return new SuccessResult(Messages.AddSuccess);
        }

        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.UpdateSuccess);
        }

        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.DeleteSuccess);
        }
    }
}
