using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
        IResult Add(int carId, IFormFile file);
        IResult Update(int id, IFormFile file);
        IResult Delete(int id);
    }
}
