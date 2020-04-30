using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IAdministratorRepository 
    {
        MessageModel GetLastMessage(Guid id);
        Task CreatePollAsync(Poll poll);

        Task AddUserASync(User user);

        Task AddInvoiceAsync(Invoice invoice);

        Task SendMessageAsync(MessageModel message);
    }
}
