using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class ApartmentHasNoInvoiceException : Exception
    {
        public ApartmentHasNoInvoiceException(Guid id) : base($"Apartment with id {id} has not invoices") { }
    }
}
