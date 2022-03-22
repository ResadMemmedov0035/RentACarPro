using Core.DataAccess;
using RentACarPro.Entities.Concrete;
using RentACarPro.Entities.DTOs;
using System.Linq.Expressions;

namespace RentACarPro.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetails();
    }

}
