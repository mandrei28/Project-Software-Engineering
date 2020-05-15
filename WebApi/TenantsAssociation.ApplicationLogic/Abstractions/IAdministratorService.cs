using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IAdministratorService
    {
        MessageView GetLastMessage(Guid id);
        Task CreatePollAsync(Poll poll);

        Task AddUserAsync(User user);

        Task AddInvoiceAsync(Invoice invoice);

        Task SendMessageAsync(MessageView message);

        List<UserView> GetAllUsers();

    }
}
