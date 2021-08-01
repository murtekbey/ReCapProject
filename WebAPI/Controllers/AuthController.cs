using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
            
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult.Data);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpPost("update")]
        public ActionResult Update(UserDetailForUpdate userDetailForUpdate)
        {
            var result = _authService.UserDetailUpdate(userDetailForUpdate);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet("isauthenticated")]
        public ActionResult IsAuthenticated(string userMail, string requiredRoles)
        {
            var rolesList = !string.IsNullOrEmpty(requiredRoles)
                ? requiredRoles.Split(',').ToList()
                : null;

            var result = _authService.IsAuthenticated(userMail, rolesList);
            if (result.Success) return Ok(result);

            return Unauthorized(result.Message);
        }
    }
}
