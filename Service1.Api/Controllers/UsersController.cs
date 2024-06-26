using Microsoft.AspNetCore.Mvc;
using Service1.Api.Application;
using Service1.Api.Application.DTOs;
using Service1.Api.Models;

namespace Service1.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] UserModel user)
        {
            var userDto = new UserDTO()
            {
                Id = user.Id,
                Name = user.Name,
                MiddleName = user.Name,
                Surname = user.Surname,
                Email = user.Email
            };
            await _userService.SendToBusAsync(userDto);

            return Ok();
        }
    }
}
