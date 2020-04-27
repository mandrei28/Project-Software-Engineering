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
        private ITokenCreator tokenCreator;
        public UserService(IUserRepository userRepository, ITokenCreator tokenCreator)
        {
            this.userRepository = userRepository;
            this.tokenCreator = tokenCreator;
        }
        public void Register(User user)
        {
            if (this.userRepository.CheckIfEmailExists(user.Email))
                throw new UserAlreadyExistsException(user.Email);
            this.userRepository.Add(user);
        }
        public string Login(User user)
        {
            if (userRepository.CheckUserCredentials(user))
            {
                var token = tokenCreator.CreateToken(user.Id, user.Name, user.Email);
                return token;
            }
            else
                throw new WrongCredentialsException(user.Email);
        }
    }

}
