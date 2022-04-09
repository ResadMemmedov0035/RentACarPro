using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentACarPro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        [HttpPost("add")]
        public IActionResult Add(int carId, IFormFile file)
        {

            return Ok();
        }
    }
}
