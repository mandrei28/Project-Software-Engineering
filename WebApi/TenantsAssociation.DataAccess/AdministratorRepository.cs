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
        public MessageModel GetLastMessage(Guid adminId)
        {
            var message = dbContext.Messages.Where(u => u.AdministratorId == adminId).OrderByDescending(m => m.DateCreated).FirstOrDefault();
            return message;
        }
        public bool CheckIfEmailExists(string email)
        {
            if (dbContext.Administrators.Any(a => a.Email == email))
                return true;
            return false;
        }

        public async Task CreatePollAsync(Poll poll)
        {
            await dbContext.Polls.AddAsync(poll);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddUserASync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await dbContext.Invoices.AddAsync(invoice);
            await dbContext.SaveChangesAsync();
        }

        public async Task SendMessageAsync(MessageModel message)
        {
            await dbContext.Messages.AddAsync(message);
            await dbContext.SaveChangesAsync();
        }
        public Guid GetAdministratorByEmail(string email)
        {
            var id = dbContext.Users.Where(u => u.Email == email).FirstOrDefault().Id;
            return id;
        }

        public string GetUserEmail(Guid id)
        {
            var email = dbContext.Users.Where(u => u.Id == id).FirstOrDefault().Email;
            return email;
        }
    }
}
