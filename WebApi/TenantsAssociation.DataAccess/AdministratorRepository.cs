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
        public Administrator CheckUserCredentials(Administrator administrator)
        {
            var adminDbo = dbContext.Administrators.SingleOrDefault(x => x.Email == administrator.Email && x.Password == administrator.Password);
            return adminDbo;
        }
    }
}
