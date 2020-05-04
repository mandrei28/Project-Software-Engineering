using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.Controllers
{

    [Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        private readonly IAdministratorService _adminService;
        public AdminController(IAdministratorService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{adminId}")]
        public MessageModel GetLastMessage(Guid adminId)
        {
            return _adminService.GetLastMessage(adminId);
        }

        [AllowAnonymous]
        [HttpPost("createPoll")]
        public async Task CreatePollAsync(Poll poll)
        {
            await _adminService.CreatePollAsync(poll);
        }

        [HttpPost("addInvoice")]
        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _adminService.AddInvoiceAsync(invoice);
        }
        [AllowAnonymous]
        [HttpPost("createUser")]
        public async Task CreateUserAsync(User user)
        {
            await _adminService.AddUserAsync(user);
        }

        [AllowAnonymous]
        [HttpPost("sendMessage")]
        public async Task SendMessageAsync(MessageView message)
        {
            await _adminService.SendMessageAsync(message);
        }
    }

}
