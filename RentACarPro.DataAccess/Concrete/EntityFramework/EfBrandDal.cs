using Core.DataAccess.EntityFramework;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarProDbContext>, IBrandDal
    {

    }
}
