using Microsoft.AspNetCore.Mvc;
using RentACarPro.Business.Abstract;
using RentACarPro.Entities.DTOs;

namespace RentACarPro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var loginResult = _authService.Login(loginDto);

            if (!loginResult.Success)
            {
                return BadRequest(loginResult);
            }

            if (loginResult.Data != null)
            {
                var result = _authService.CreateAccessToken(loginResult.Data);

                if (!result.Success) 
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterDto registerDto)
        {
            var registerResult = _authService.Register(registerDto);

            if (!registerResult.Success)
            {
                return BadRequest(registerResult);
            }

            if (registerResult.Data != null)
            {
                var result = _authService.CreateAccessToken(registerResult.Data);

                if (!result.Success) 
                {
                    return BadRequest(result);
                }
                return Ok(result);
            }
            return BadRequest();
        }
    }
}
