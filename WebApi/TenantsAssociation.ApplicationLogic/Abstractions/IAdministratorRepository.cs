using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Administrator CheckUserCredentials(Administrator administrator);
    }
}
