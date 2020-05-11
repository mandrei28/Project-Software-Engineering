using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
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

        public void ChangeName(YourAccountName name, Guid userId)
        {
            try
            {
                var user = userRepository.GetUserByUserId(userId);
                if (user != null)
                {
                    user.Name = name.name;
                    userRepository.Update(user);
                }
            }
            catch
            {
                try
                {
                    var admin = administratorRepository.GetAdministratorByUserId(userId);
                    if (admin != null)
                    {
                        admin.Name = name.name;
                        administratorRepository.Update(admin);
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
        public void ChangePassword(YourAccountPassword password, Guid userId)
        {
            try
            {
                var user = userRepository.GetUserByUserId(userId);
                if (user != null)
                {
                    if (user.Password == password.currentPassword)
                    {
                        user.Password = password.newPassword;
                        userRepository.Update(user);
                    }
                    else
                        throw new Exception();
                }
            }
            catch
            {
                try
                {
                    var admin = administratorRepository.GetAdministratorByUserId(userId);
                    if (admin != null)
                    {
                        if (admin.Password == password.currentPassword)
                        {
                            admin.Password = password.newPassword;
                            administratorRepository.Update(admin);
                        }
                        else
                            throw new Exception();
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
        public void ChangeEmail(YourAccountEmail email, Guid userId)
        {
            if (userRepository.CheckIfEmailExists(email.email))
                throw new Exception();
            try
            {
                var user = userRepository.GetUserByUserId(userId);
                if (user != null)
                {
                    user.Email = email.email;
                    userRepository.Update(user);
                }
            }
            catch
            {
                try
                {
                    var admin = administratorRepository.GetAdministratorByUserId(userId);
                    if (admin != null)
                    {
                        admin.Email = email.email;
                        administratorRepository.Update(admin);
                    }
                }
                catch
                {
                    throw new Exception();
                }
            }
        }
    }
}
