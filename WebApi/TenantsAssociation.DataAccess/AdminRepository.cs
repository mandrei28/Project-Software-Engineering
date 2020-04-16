using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.DataAccess
{
    public class AdminRepository : BaseRepository<MessageModel> , IAdministratorRepository
    {
        public AdminRepository(TenantsAssociationDbContext dbContext) : base(dbContext)
        {
        }

        public MessageModel GetLastMessage(Guid adminId)
        {
            var message = dbContext.Messages.Where(u => u.Id == adminId).OrderByDescending(m => m.DateCreated).FirstOrDefault();
            return message;
        }

    }
}
