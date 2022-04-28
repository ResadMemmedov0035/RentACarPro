using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACarPro.Business.Abstract;

namespace RentACarPro.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }

        [HttpGet("getallbycar")]
        public IActionResult GetAll(int carId)
        {
            var result = _carImageService.GetAllByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")]
        public IActionResult Add(int carId, IFormFile file)
        {
            var result = _carImageService.Add(carId, file);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
