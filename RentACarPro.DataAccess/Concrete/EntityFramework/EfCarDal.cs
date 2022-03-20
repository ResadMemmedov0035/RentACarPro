using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using Core.DataAccess.EntityFramework;

namespace RentACarPro.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarProDbContext>, ICarDal
    {
    }
}
