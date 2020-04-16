using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void CreatePoll(Poll poll)
        {
            dbContext.Polls.Add(poll);
        }

    }
}
