using Core.DataAccess.EntityFramework;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.DataAccess.Concrete.EntityFramework
{
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarProDbContext>, ICustomerDal
    {

    }
}
