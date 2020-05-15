using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IAdministratorRepository : IRepository<Administrator>
    {
        Administrator CheckUserCredentials(Administrator administrator);

        Administrator GetAdministratorByUserId(Guid userId);

        bool CheckIfEmailExists(string email);

        MessageModel GetLastMessage(Guid id);

        Task CreatePollAsync(Poll poll);

        Task AddUserASync(User user);

        Task AddInvoiceAsync(Invoice invoice);

        Task SendMessageAsync(MessageModel message);

        Guid GetAdministratorByEmail(string email);

        string GetUserEmail(Guid id);

        List<User> GetAllUsers();

        int GetApartmentsNumber(Guid userId);
        Administrator GetRandomAdministrator();
    }
}
