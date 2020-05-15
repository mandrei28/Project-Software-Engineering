using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserNotFoundException : Exception
    {
        public UserNotFoundException(Guid id) : base($"User with {id} doesn't exist") { }
    }
}
