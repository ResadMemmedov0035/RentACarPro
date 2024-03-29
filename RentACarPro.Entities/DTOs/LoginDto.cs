﻿using Core.Entities.Abstract;

namespace RentACarPro.Entities.DTOs
{
    public class LoginDto : IDto 
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
