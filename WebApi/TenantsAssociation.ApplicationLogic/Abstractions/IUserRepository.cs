using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;
namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUserId(Guid userId);

        bool CheckIfEmailExists(string email);
        bool CheckUserCredentials(User user);
    }
}
