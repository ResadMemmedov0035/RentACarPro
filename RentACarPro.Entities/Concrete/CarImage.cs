using Core.Entities.Abstract;

namespace RentACarPro.Entities.Concrete
{
    public class CarImage : IEntity
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
