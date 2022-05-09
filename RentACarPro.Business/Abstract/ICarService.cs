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
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetAllDetails();
        IDataResult<Car> GetById(int id);
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        //IResult AddTransactional(Car car);
    }
}
