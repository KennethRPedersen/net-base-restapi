using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.AppServices.Interfaces;
using Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using restapi_base.Helpers.Interfaces;

namespace restapi_base.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IAuthenticationHelper _authenticationHelper;
        private readonly ILogger<UsersController> _logger;

        public UsersController(IUserService userService,
            IAuthenticationHelper authHelper,
            ILogger<UsersController> logger)
        {
            _userService = userService;
            _authenticationHelper = authHelper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticationModel model)
        {
            try
            {
                var user = _userService.Authenticate(model);

                if (user == null)
                    return BadRequest("Username or password is incorrect");
                else
                    // Authentication successful
                    return Ok(new
                    {
                        username = user.Email,
                        token = _authenticationHelper.GenerateToken(user)
                    });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            _userService.CreateUser(user);
            return Ok();
        }
    }
}