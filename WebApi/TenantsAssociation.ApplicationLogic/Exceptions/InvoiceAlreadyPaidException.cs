using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class InvoiceAlreadyPaidException : Exception
    {
        public InvoiceAlreadyPaidException(Guid id) : base($"Invoice with {id} has been already paid") { }
    }
}
