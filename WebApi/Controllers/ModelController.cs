using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class ModelController: BaseController
    {
        IModelService _modelService;
        public ModelController(IModelService modelService) 
        {
            _modelService = modelService;
        }

        [HttpPost("Add")]
        public IActionResult Add(Model model)
        {
            _modelService.Add(model);
            return Created();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _modelService.GetAll();

            return Ok(result);
        }
    }
}
