using AspNetCore.API.Core.Entities;
using AspNetCore.API.Core.Models;
using AspNetCore.API.Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCore.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly IApplicationUserService _userService;

        public UserController(
            IApplicationUserService userService
        )
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationUser>> GetAllApplicationUsersAsync()
            => await _userService.GetAllApplicationUsersAsync();


        [HttpGet("{userName}")]
        public async Task<Guid> GetuserIdByUsernameAsync(string userName)
            => (await _userService.GetApplicationUserByUserNameAsync(userName)).UserId;
    }
}
