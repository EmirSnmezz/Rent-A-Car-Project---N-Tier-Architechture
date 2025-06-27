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

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);

            if(result.IsSuccess)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);

            if(result.IsSuccess)
                return Ok(result.Message);

            return BadRequest(result.Message);
        }

        [HttpPost("getbyid")]
        public IActionResult GetById([FromBody] int id)
        {
            var result = _carService.GetById(id);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpPost ("getbybrandid")]
        public IActionResult GetByBrandId(int brandId)
        {
            var result = _carService.GetByBrandId(brandId);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getbyprice")]
        public IActionResult GetByPrice(int minValue, int maxValue)
        {
            var result = _carService.GetByPrice(minValue, maxValue);

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

        [HttpGet("getcardetail")]
        public IActionResult GetAllCarDetails()
        {
            var result = _carService.GetCarDetails();

            if(result.IsSuccess)
                return Ok(result.Data);

            return BadRequest(result.Message);
        }

    }
}
