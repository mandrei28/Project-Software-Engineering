using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Exceptions
{
    public class AdminHasNoMessageException : Exception
    {
        public AdminHasNoMessageException(Guid id) : base($"Admin with id {id} has not message") { }
    }
}
