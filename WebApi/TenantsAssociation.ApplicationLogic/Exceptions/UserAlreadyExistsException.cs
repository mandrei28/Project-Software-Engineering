using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException(string email) : base($"User with email {email} already exists") { }
    }
}
