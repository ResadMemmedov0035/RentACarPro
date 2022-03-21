using Core.DataAccess.EntityFramework;
using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;

namespace RentACarPro.DataAccess.Concrete.EntityFramework
{
    public class EfModelDal : EfEntityRepositoryBase<Model, RentACarProDbContext>, IModelDal
    {

    }
}
