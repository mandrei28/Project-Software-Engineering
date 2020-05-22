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
        
        public AdministratorService(IAdministratorRepository administratorRepository)
        {
            this.administratorRepository = administratorRepository;
            
        }
        public MessageView GetLastMessage(Guid id)
        {
            var lastMessage = administratorRepository.GetLastMessage(id);
            if (lastMessage == null)
            {
                throw new AdminHasNoMessageException(id);
            }
            var email = administratorRepository.GetUserEmail(lastMessage.UserId);
            if(email == null)
            {
                throw new UserHasNoEmailException(id);
            }
            return new MessageView { DateCreated = lastMessage.DateCreated, Text = lastMessage.Text, Email = email };

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
            MessageModel newMessage = CreateMessage(message);
            await this.administratorRepository.SendMessageAsync(newMessage);
        }

        public MessageModel CreateMessage(MessageView message)
        {
            var userId = administratorRepository.GetUserByEmail(message.Email);
            if(userId == Guid.Empty)
            {
                throw new UserDontExistException(message.Email);
            }
            return new MessageModel
            {
                UserId = userId,
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
