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
    }
}