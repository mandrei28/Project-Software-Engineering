using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Exceptions;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.ApplicationLogic.Tests
{
    [TestClass]
    public class AdminServiceLogicTests
    {

        [TestMethod]
        public void GetLastMessage_ThrowsException_AdminHasNoMessageException()
        {


            //Arrange
            Mock<IAdministratorRepository> adminRepositoryMock = new Mock<IAdministratorRepository>();

            Administrator administator = new Administrator
            {
                Id = Guid.NewGuid(),
                Email = "florin@gmail.com"
            };

            MessageModel message = null;

            adminRepositoryMock.Setup(adminRepository => adminRepository.GetLastMessage(administator.Id)).Returns(message);
            AdministratorService administratorService = new AdministratorService(adminRepositoryMock.Object);
            //Assert            
            Assert.ThrowsException<AdminHasNoMessageException>(() => { administratorService.GetLastMessage(administator.Id); });

        }


        [TestMethod]
        public void GetLastMessage_ThrowsException_AdminHasNoEmailException()
        {


            //Arrange
            Mock<IAdministratorRepository> adminRepositoryMock = new Mock<IAdministratorRepository>();

            Administrator administator = new Administrator
            {
                Id = Guid.NewGuid(),
                Email = null
            };

            MessageModel message = new MessageModel
            {
                AdministratorId = administator.Id
            };

            adminRepositoryMock.Setup(adminRepository => adminRepository.GetLastMessage(administator.Id)).Returns(message);
            AdministratorService administratorService = new AdministratorService(adminRepositoryMock.Object);
            //Assert            
            Assert.ThrowsException<UserHasNoEmailException>(() => { administratorService.GetLastMessage(administator.Id); });

        }

        [TestMethod]
        public void GetLastMessage_Return_Message()
        {


            //Arrange
            Mock<IAdministratorRepository> adminRepositoryMock = new Mock<IAdministratorRepository>();

            Administrator administator = new Administrator
            {
                Id = Guid.NewGuid(),
                Email = "florin@gmail.com"
            };

            User user = new User
            {
                Id = Guid.NewGuid(),
                Email = "florin@gmail.com"
            };

            MessageModel message = new MessageModel
            {
                AdministratorId = administator.Id,
                Text = "ce faci?",
                UserId = user.Id,
                DateCreated = DateTime.Parse("10/10/2020")
            };

            MessageView messageView = new MessageView
            {
                DateCreated = message.DateCreated,
                Text = message.Text,
                Email = user.Email
            };

            adminRepositoryMock.Setup(adminRepository => adminRepository.GetLastMessage(administator.Id)).Returns(message);
            adminRepositoryMock.Setup(adminRepository => adminRepository.GetUserEmail(message.UserId)).Returns(user.Email);
            AdministratorService administratorService = new AdministratorService(adminRepositoryMock.Object);
            //Assert            
            Assert.AreEqual(administratorService.GetLastMessage(administator.Id).Text, messageView.Text);

        }

        


        [TestMethod]
        public void CreateMessage_ThrowsException_UserDontExistException()
        {


            //Arrange
            Mock<IAdministratorRepository> adminRepositoryMock = new Mock<IAdministratorRepository>();

            MessageView messageView = new MessageView
            {
                Email = "florin@gmail.com",
                Text ="ce faci ?",
                AdministratorId = Guid.NewGuid().ToString()
            };

            Guid userId = Guid.Empty;
            adminRepositoryMock.Setup(adminRepository => adminRepository.GetUserByEmail(messageView.Email)).Returns(userId); 
            AdministratorService administratorService = new AdministratorService(adminRepositoryMock.Object);
            //Assert            
            Assert.ThrowsException<UserDontExistException>(() => { administratorService.CreateMessage(messageView); });

        }

        [TestMethod]
        public void CreateMessage_ReturnMessage()
        {


            //Arrange
            Mock<IAdministratorRepository> adminRepositoryMock = new Mock<IAdministratorRepository>();

            MessageView messageView = new MessageView
            {
                Email = "florin@gmail.com",
                Text = "ce faci ?",
                AdministratorId = Guid.NewGuid().ToString()
            };

            Guid userId = Guid.NewGuid();

            MessageModel message = new MessageModel
            {
                UserId = userId,
                Text = messageView.Text,
                AdministratorId = Guid.NewGuid(),
                DateCreated = DateTime.Parse("10/10/2020")
            };

            adminRepositoryMock.Setup(adminRepository => adminRepository.GetUserByEmail(messageView.Email)).Returns(userId);
            AdministratorService administratorService = new AdministratorService(adminRepositoryMock.Object);
            //Assert            
            Assert.AreEqual( administratorService.CreateMessage(messageView).Text , message.Text);

        }
    }
}
