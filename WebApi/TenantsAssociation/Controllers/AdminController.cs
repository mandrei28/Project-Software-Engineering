using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
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

        [HttpGet("createPoll")]
        public async Task CreatePollAsync(Poll poll)
        {
            await _adminService.CreatePollAsync(poll);
        }

        [HttpGet("addInvoice")]
        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _adminService.AddInvoiceAsync(invoice);
        }

        [HttpGet("createUser")]
        public async Task CreateUserAsync(User user)
        {
            await _adminService.AddUserAsync(user);
        }

        [HttpGet("sendMessage")]
        public async Task SendMessageAsync(MessageModel message)
        {
            await _adminService.SendMessageAsync(message);
        }
    }

}
