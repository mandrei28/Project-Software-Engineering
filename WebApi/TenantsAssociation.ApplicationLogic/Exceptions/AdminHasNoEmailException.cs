using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class UserHasNoEmailException : Exception
    {
        public UserHasNoEmailException(Guid id) : base($"User with id {id} has not email") { }
    }
}
