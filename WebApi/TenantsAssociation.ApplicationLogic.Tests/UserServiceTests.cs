using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Exceptions;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.ApplicationLogic.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void Login_ThrowsException_WrongCredentialsExceptionForBothUserAndAdministrator()
        {
            //Arrange
            Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();
            Mock<IAdministratorRepository> adminRepoMock = new Mock<IAdministratorRepository>();
            IOptions<AppSettings> _appSettings = Options.Create<AppSettings>(new AppSettings());
            Mock<IMapper> mapper = new Mock<IMapper>();
            ITokenCreator tokenCreator = new TokenCreator(_appSettings);

            User user = new User()
            {
                Email = "test@test.com",
                Password = "asd12345test",
            };

            Administrator administrator = new Administrator()
            {
                Email = "test@test.com",
                Password = "asd12345test",
            };

            User badUser = null;

            Administrator badAdministrator = null;

            mapper.Setup(m => m.Map<User, Administrator>(It.IsAny<User>())).Returns(administrator);
            Administrator admin = mapper.Object.Map<Administrator>(user);

            userRepoMock.Setup(userRepository => userRepository.CheckUserCredentials(user)).Returns(badUser);
            adminRepoMock.Setup(adminRepository => adminRepository.CheckUserCredentials(admin)).Returns(badAdministrator);

            UserService userService = new UserService(mapper.Object, userRepoMock.Object, tokenCreator, adminRepoMock.Object);

            //Act

            //Assert
            Assert.ThrowsException<WrongCredentialsException>(() => userService.Login(user));
        }
        [TestMethod]
        public void Login_ThrowsException_WrongCredentialsExceptionForUserButNotForAdministrator()
        {
            //Arrange
            Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();
            Mock<IAdministratorRepository> adminRepoMock = new Mock<IAdministratorRepository>();
            IOptions<AppSettings> _appSettings = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "secrettttttttttttttttttttttttttt"
            });
            Mock<IMapper> mapper = new Mock<IMapper>();
            ITokenCreator tokenCreator = new TokenCreator(_appSettings);

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test@test.com",
                Password = "asd12345test",
            };

            Administrator administrator = new Administrator()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test@test.com",
                Password = "asd12345test",
            };

            User badUser = null;

            Administrator badAdministrator = null;

            mapper.Setup(m => m.Map<User, Administrator>(It.IsAny<User>())).Returns(administrator);
            Administrator admin = mapper.Object.Map<Administrator>(user);

            userRepoMock.Setup(userRepository => userRepository.CheckUserCredentials(user)).Returns(badUser);
            adminRepoMock.Setup(adminRepository => adminRepository.CheckUserCredentials(admin)).Returns(administrator);

            UserService userService = new UserService(mapper.Object, userRepoMock.Object, tokenCreator, adminRepoMock.Object);

            //Act
            var token = userService.Login(user);
            //Assert
            Assert.IsTrue(token != null);
        }
        [TestMethod]
        public void Login_ThrowsException_WrongCredentialsExceptionForAdminButNotForUser()
        {
            //Arrange
            Mock<IUserRepository> userRepoMock = new Mock<IUserRepository>();
            Mock<IAdministratorRepository> adminRepoMock = new Mock<IAdministratorRepository>();
            IOptions<AppSettings> _appSettings = Options.Create<AppSettings>(new AppSettings()
            {
                Secret = "secrettttttttttttttttttttttttttt"
            });
            Mock<IMapper> mapper = new Mock<IMapper>();
            ITokenCreator tokenCreator = new TokenCreator(_appSettings);

            User user = new User()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test@test.com",
                Password = "asd12345test",
            };

            Administrator administrator = new Administrator()
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                Email = "test@test.com",
                Password = "asd12345test",
            };

            User badUser = null;

            Administrator badAdministrator = null;

            mapper.Setup(m => m.Map<User, Administrator>(It.IsAny<User>())).Returns(administrator);
            Administrator admin = mapper.Object.Map<Administrator>(user);

            userRepoMock.Setup(userRepository => userRepository.CheckUserCredentials(user)).Returns(user);
            adminRepoMock.Setup(adminRepository => adminRepository.CheckUserCredentials(admin)).Returns(badAdministrator);

            UserService userService = new UserService(mapper.Object, userRepoMock.Object, tokenCreator, adminRepoMock.Object);

            //Act
            var token = userService.Login(user);
            //Assert
            Assert.IsTrue(token != null);
        }
    }
}
