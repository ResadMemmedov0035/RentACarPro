using Core.Utilities.Results;
using RentACarPro.Entities.Concrete;
using RentACarPro.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarPro.Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<List<Car>> GetAllCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetAllCarsByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();
        IDataResult<Car?> GetCarById(int id);
        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);
    }
}
