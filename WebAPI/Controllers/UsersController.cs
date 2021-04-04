using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getuserdetailbymail")]
        public IActionResult GetUserDetailByMail(string userMail)
        {
            var result = _userService.GetByMail(userMail);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
