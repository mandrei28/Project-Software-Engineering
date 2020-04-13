using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.DataAccess
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(TenantsAssociationDbContext dbContext) : base(dbContext)
        {
        }
        public List<Invoice> GetUserInvoices(Guid userId)
        {
            var apartments = dbContext.Apartments.Where(apartment => apartment.User.Id == userId).Select(apartment => apartment.Id).ToList();
            var invoices = dbContext.Invoices.Where(invoice => apartments.Contains<Guid>(invoice.Apartment.Id));
            return invoices.ToList();
        }
    }
}
