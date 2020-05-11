using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TenantsAssociationDbContext dbContext) : base(dbContext)
        {
        }
        public User GetUserByUserId(Guid userId)
        {
            var user = dbContext.Users.Where(u => u.Id == userId).Include(u => u.Apartments).ThenInclude(a => a.Invoices).FirstOrDefault();
            if (user == null)
                throw new UserNotFoundException(userId);
            return user;
        }
        public bool CheckIfEmailExists(string email)
        {
            if (dbContext.Users.Any(u => u.Email == email))
                return true;
            return false;
        }
        public User CheckUserCredentials(User user)
        {
            var userDbo = dbContext.Users.SingleOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            return userDbo;
        }
    }
}
