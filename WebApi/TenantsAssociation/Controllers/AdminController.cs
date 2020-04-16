using Microsoft.AspNetCore.Mvc;
using System;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        private AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{adminId}")]
        public MessageModel GetLastMessage(Guid adminId) 
        {
            return _adminService.GetLastMessage(adminId);
        }
    }

}
