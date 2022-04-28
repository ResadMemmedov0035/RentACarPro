using Core.DataAccess;
using Core.Entities.Concrete;

namespace RentACarPro.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
