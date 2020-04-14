using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [HttpGet("invoices/{userId}")]
        public IEnumerable<Invoice> GetUserInvoices(string userId)
        {
            var invoices = userService.GetUserInvoices(userId);
            return invoices;
        }

    }
}