using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserDontExistException : Exception
    {
        public UserDontExistException(string email) : base($"User with email {email} don't exist") { }
    }
}
