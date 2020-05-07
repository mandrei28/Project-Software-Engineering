using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.DataAccess
{
    public class InvoiceRepository : BaseRepository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(TenantsAssociationDbContext dbContext) : base(dbContext)
        {
        }
        public Invoice GetInvoiceByInvoiceId(Guid invoiceId)
        {
            var invoice = dbContext.Invoices.SingleOrDefault(i => i.Id == invoiceId);
            return invoice;
        }
    }
}
