using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class UserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public void Register(User user)
        {
            if (this.userRepository.CheckIfEmailExists(user.Email))
                throw new UserAlreadyExistsException(user.Email);
            this.userRepository.Add(user);
        }
    }
}
