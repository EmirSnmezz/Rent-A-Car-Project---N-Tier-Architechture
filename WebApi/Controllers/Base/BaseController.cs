using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.Base
{
    [Route("api/{controller}")]
    [ApiController]
    public class BaseController : ControllerBase
    {
    }
}
