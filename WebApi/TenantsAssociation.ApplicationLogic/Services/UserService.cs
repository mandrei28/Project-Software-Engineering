using AutoMapper;
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
        private readonly IMapper autoMapper;
        private readonly IAdministratorRepository administratorRepository;
        public UserService(IMapper autoMapper, IUserRepository userRepository, ITokenCreator tokenCreator, IAdministratorRepository administratorRepository)
        {
            this.userRepository = userRepository;
            this.tokenCreator = tokenCreator;
            this.administratorRepository = administratorRepository;
            this.autoMapper = autoMapper;
        }
        public void Register(User user)
        {
            if (this.userRepository.CheckIfEmailExists(user.Email))
                throw new UserAlreadyExistsException(user.Email);
            this.userRepository.Add(user);
        }
        public string Login(User user)
        {
            var userDbo = userRepository.CheckUserCredentials(user);

            if (userDbo != null)
            {
                var token = tokenCreator.CreateToken(userDbo.Id, userDbo.Name, userDbo.Email, "user");
                return token;
            }
            else
            {
                Administrator administrator = autoMapper.Map<Administrator>(user);
                var administratorDbo = administratorRepository.CheckUserCredentials(administrator);
                if (administratorDbo != null)
                {
                    var token = tokenCreator.CreateToken(administratorDbo.Id, administratorDbo.Name, administratorDbo.Email, "admin");
                    return token;
                }
            }
            throw new WrongCredentialsException(user.Email);
        }
    }
}
