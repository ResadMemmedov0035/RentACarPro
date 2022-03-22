using RentACarPro.DataAccess.Abstract;
using RentACarPro.Entities.Concrete;
using Core.DataAccess.EntityFramework;
using RentACarPro.Entities.DTOs;
using System.Linq.Expressions;

namespace RentACarPro.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarProDbContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using var context = new RentACarProDbContext();

            var query = from c in context.Cars
                        join b in context.Brands on c.BrandId equals b.Id
                        join m in context.Models on c.ModelId equals m.Id
                        join cl in context.Colors on c.ColorId equals cl.Id
                        select new CarDetailDto
                        {
                            Id = c.Id,
                            BrandName = b.Name,
                            ModelName = m.Name,
                            ColorName = cl.Name,
                            ModelYear = c.ModelYear,
                            DailyPrice = c.DailyPrice,
                            Description = c.Description
                        };
            return query.ToList();
        }
    }
}
