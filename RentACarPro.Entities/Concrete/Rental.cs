﻿using Core.Entities.Abstract;

namespace RentACarPro.Entities.Concrete
{
    public class Rental : IEntity 
    {
        public int Id { get; set; }
        public int CarId { get; set; }
        public int CustomerId { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
