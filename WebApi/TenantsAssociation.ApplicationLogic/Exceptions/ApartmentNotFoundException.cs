using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class ApartmentNotFoundException : Exception
    {
        public ApartmentNotFoundException(Guid id) : base($"Apartment with id {id} doesn't exist") { }
    }
}
