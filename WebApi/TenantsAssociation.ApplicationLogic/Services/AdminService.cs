using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class AdminService : IAdministratorService
    {

        private readonly IAdministratorRepository _repository;

        public AdminService(IAdministratorRepository repository)
        {
            _repository = repository;
        }

        public MessageModel GetLastMessage(Guid id)
        {
            return _repository.GetLastMessage(id);
        }

        public async Task CreatePollAsync(Poll poll)
        {
            await _repository.CreatePollAsync(poll);
        }
        public async Task AddUserAsync(User user)
        {
            await _repository.AddUserASync(user);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await _repository.AddInvoiceAsync(invoice);
        }

        public async Task SendMessageAsync(MessageModel message)
        {
            await _repository.SendMessageAsync(message);
        }

        public async Task AddNewsAsync(News news)
        {
            await _repository.AddNewsAsync(news);
        }
    }
}
