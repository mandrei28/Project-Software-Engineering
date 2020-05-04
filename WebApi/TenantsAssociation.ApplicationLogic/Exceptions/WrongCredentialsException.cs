using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class WrongCredentialsException : Exception
    {
        public WrongCredentialsException(string email) : base($"The password entered for the email {email} was wrong") { }
    }
}
