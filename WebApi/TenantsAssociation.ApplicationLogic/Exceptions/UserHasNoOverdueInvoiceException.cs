using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserHasNoOverdueInvoiceException : Exception
    {
        public UserHasNoOverdueInvoiceException() : base($"Current user has no overdue invoices") { }
    }
}
