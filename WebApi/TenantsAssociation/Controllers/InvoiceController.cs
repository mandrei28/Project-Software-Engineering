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
    public class InvoiceController : Controller
    {
        private readonly InvoiceService invoiceService;
        public InvoiceController(InvoiceService invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpGet("{userId}")]
        public IEnumerable<Invoice> GetUserInvoices(Guid userId)
        {
            var invoices = invoiceService.GetAllInvoices(userId);
            return invoices;
        }
        [HttpPost("{userId}")]
        public IEnumerable<Invoice> GetUserOverdueInvoices([FromBody]DueDate dueDate, Guid userId)
        {
            var invoices = invoiceService.GetAllOverdueInvoices(userId, dueDate);
            return invoices;

        }
        [HttpGet("edit/{invoiceId}")]
        public Invoice GetInvoiceById(Guid invoiceId)
        {
            var invoice = invoiceService.GetInvoiceByInvoiceId(invoiceId);
            return invoice;
        }
        [HttpPost("pay/{invoiceId}")]
        public IActionResult PayInvoice(Guid invoiceId)
        {
            try
            {
                invoiceService.PayInvoice(invoiceId);
                return Ok();
            }
            catch
            {
                return Unauthorized();
            }
        }
    }
}