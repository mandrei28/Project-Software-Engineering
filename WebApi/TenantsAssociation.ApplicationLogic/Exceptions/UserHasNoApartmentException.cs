using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserHasNoApartmentException : Exception
    {
        public UserHasNoApartmentException() : base($"Current user has no apartments") { }
    }
}
