using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class AdminService : IAdminService
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

        public void CreatePoll(Poll poll)
        {
            _repository.CreatePoll(poll);
        }
    }
}
