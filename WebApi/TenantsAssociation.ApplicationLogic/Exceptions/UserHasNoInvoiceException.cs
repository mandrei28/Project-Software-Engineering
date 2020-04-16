using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserHasNoInvoiceException : Exception
    {
        public UserHasNoInvoiceException(Guid id) : base($"User with id {id} has not invoices") { }
    }
}
