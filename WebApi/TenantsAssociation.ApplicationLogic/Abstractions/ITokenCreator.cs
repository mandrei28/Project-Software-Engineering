using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface ITokenCreator
    {
        string CreateToken(Guid userId, string name, string email, string role);
    }
}
