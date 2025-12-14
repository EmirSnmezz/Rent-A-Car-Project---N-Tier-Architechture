using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class BrandController : BaseController
    {

        IBrandService _brandService;

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpPost("Add")]

        public IActionResult AddBrand(Brand brand)
        {
            var result = _brandService.Add(brand);

            if(result.IsSuccess)
            {
                return Created();
            }

            return BadRequest(result.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAllBrand()
        {
            var result = _brandService.GetAll();
            return Ok(result);
        }
    }
}
