using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.DataAccess
{
    public class AdministratorRepository : BaseRepository<Administrator>, IAdministratorRepository
    {
        public AdministratorRepository(TenantsAssociationDbContext dbContext) : base(dbContext)
        {
        }
        public Administrator GetAdministratorByUserId(Guid userId)
        {
            var user = dbContext.Administrators.Where(a => a.Id == userId).Include(a => a.Buildings).ThenInclude(b => b.Polls).FirstOrDefault();
            return user;
        }
        public Administrator CheckUserCredentials(Administrator administrator)
        {
            var adminDbo = dbContext.Administrators.SingleOrDefault(x => x.Email == administrator.Email && x.Password == administrator.Password);
            return adminDbo;
        }
    }
}
