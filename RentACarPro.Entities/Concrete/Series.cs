using Core.Entities;

namespace RentACarPro.Entities.Concrete
{
    public class Series : IEntity
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
