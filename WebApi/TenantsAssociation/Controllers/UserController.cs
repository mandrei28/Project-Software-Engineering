using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.Controllers
{
    [Authorize(AuthenticationSchemes =
    JwtBearerDefaults.AuthenticationScheme)]
    [Route("[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register([FromBody]User userModel)
        {
            try
            {
                this.userService.Register(userModel);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User user)
        {
            try
            {
                var token = userService.Login(user);
                return Ok(new
                {
                    Token = token
                });
            }
            catch
            {
                return Unauthorized();
            }
        }
        [HttpPost("name/{userId}")]
        public IActionResult ChangeName([FromBody]YourAccountName name, Guid userId)
        {
            try
            {
                userService.ChangeName(name, userId);
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }
        [HttpPost("password/{userId}")]
        public IActionResult ChangePassword([FromBody]YourAccountPassword password, Guid userId)
        {
            try
            {
                userService.ChangePassword(password, userId);
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }
        [HttpPost("email/{userId}")]
        public IActionResult ChangeEmail([FromBody]YourAccountEmail email, Guid userId)
        {
            try
            {
                userService.ChangeEmail(email, userId);
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}