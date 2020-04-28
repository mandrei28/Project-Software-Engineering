using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.Controllers
{
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
    }
}