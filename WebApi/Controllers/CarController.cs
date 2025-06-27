using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class CarController : BaseController
    {
        ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            //var result = _carService.GetCarDetails();
            var result = _carService.GetAll();

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        public IActionResult Add(CarAddDto carDto)
        {
            var result = _carService.Add(carDto);

            if (result.IsSuccess)
                return Ok(result.Message);

            return BadRequest(result.Message);

        }
    }
}
