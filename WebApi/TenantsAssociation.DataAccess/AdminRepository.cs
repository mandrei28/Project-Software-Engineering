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

        public async Task CreatePollAsync(Poll poll)
        {
            await dbContext.Polls.AddAsync(poll);
        }

        public async Task AddUserASync(User user)
        {
            await dbContext.Users.AddAsync(user);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
           await dbContext.Invoices.AddAsync(invoice);
        }

        public async Task SendMessageAsync(MessageModel message)
        {
            await dbContext.Messages.AddAsync(message);
        }
    }
}
