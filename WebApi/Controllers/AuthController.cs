using Business.Abstract;
using Entities.DTOs.UserDtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers.Base;

namespace WebApi.Controllers
{
    public class AuthController : BaseController
    {
        private IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }


        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExist = _authService.UserExist(userForRegisterDto.Email);

            if (userExist.IsSuccess)
            {
                return BadRequest(userExist.Message);
            }

            var userToRegister = _authService.Register(userForRegisterDto, userForRegisterDto.Password);

            if (!userToRegister.IsSuccess)
            {
                return BadRequest(userToRegister.Message);
            }

            return Ok(userToRegister.Message);
        }
    }
}
