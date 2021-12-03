using System;
using System.Threading.Tasks;
using HealthAssessment.DTOs;
using HealthAssessment.Models;
using HealthAssessment.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace HealthAssessment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;
        public UserController(DBContext context)
        {
            _userService = new UserService(context);
        }

        [HttpPost("CreateUser")]
        public async Task<ActionResult<UserDtos>> CreateUser(UserDtos user)
        {
            return await _userService.CreateUser(user);
        }

        [HttpPost("LoginUser")]
        public bool LoginUser(Login user)
        {
            return _userService.LoginUser(user);
        }
    }
}
