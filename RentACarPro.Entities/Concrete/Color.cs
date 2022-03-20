﻿using Core.Entities;

namespace RentACarPro.Entities.Concrete
{
    public class Color : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
    }
}
