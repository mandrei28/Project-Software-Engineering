using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class AdministratorService : IAdministratorService
    {
        private readonly IAdministratorRepository administratorRepository;
        private ITokenCreator tokenCreator;
        public AdministratorService(IAdministratorRepository administratorRepository, ITokenCreator tokenCreator)
        {
            this.administratorRepository = administratorRepository;
            this.tokenCreator = tokenCreator;
        }
        public MessageView GetLastMessage(Guid id)
        {
            var lastMessage = administratorRepository.GetLastMessage(id);
            return new MessageView { DateCreated = lastMessage.DateCreated, Text = lastMessage.Text, Email = administratorRepository.GetUserEmail(lastMessage.UserId) };

        }

        public async Task CreatePollAsync(Poll poll)
        {
            await this.administratorRepository.CreatePollAsync(poll);
        }
        public async Task AddUserAsync(User user)
        {
            await this.administratorRepository.AddUserASync(user);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            await this.administratorRepository.AddInvoiceAsync(invoice);
        }

        public async Task SendMessageAsync(MessageView message)
        {
            MessageModel newMessage = createMessage(message);
            await this.administratorRepository.SendMessageAsync(newMessage);
        }

        private MessageModel createMessage(MessageView message)
        {
            return new MessageModel
            {
                UserId = administratorRepository.GetAdministratorByEmail(message.Email),
                Text = message.Text,
                AdministratorId = Guid.Parse(message.AdministratorId),
                DateCreated = DateTime.Now
            };
        }

        public List<UserView> GetAllUsers()
        {
            var users = administratorRepository.GetAllUsers();
            List<UserView> userViews = new List<UserView>();
            int no = 1;
            foreach(var user in users)
            {
                userViews.Add(
                    new UserView
                    {
                        No = no++,
                        Name = user.Name,
                        ApartmentNo = administratorRepository.GetApartmentsNumber(user.Id),
                        Email = user.Email

                    });
            }

            return userViews;
        }

    }
}
