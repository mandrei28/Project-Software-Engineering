using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Exceptions;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.ApplicationLogic.Tests
{
    [TestClass]
    public class InvoiceLogicTests
    {
        [TestMethod]
        public void GetAllInvoices_ThrowsException_WhenUserDoesNotExist()
        {
            //arrange
            Guid badGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(badGuid)).Throws(new UserNotFoundException(badGuid));
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<UserNotFoundException>(() =>
            {
                invoiceService.GetAllInvoices(badGuid);
            });
        }
        [TestMethod]
        public void GetAllInvoices_ThrowsException_WhenUserHasNoApartments()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            var user = new User
            {
                Id = goodGuid,
                Email = "mail@mail.com",
                Name = "testName",
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);

            //act

            //assert
            Assert.ThrowsException<UserHasNoApartmentException>(() =>
            {
                invoiceService.GetAllInvoices(goodGuid);
            });
        }
        [TestMethod]
        public void GetAllInvoices_ThrowsException_WhenUserHasNoInvoices()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= Guid.NewGuid(),
                    ApartmentNumber = 20,
                }
            };

            var user = new User
            {
                Id = goodGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);

            //act

            //assert
            Assert.ThrowsException<UserHasNoInvoiceException>(() =>
            {
                invoiceService.GetAllInvoices(goodGuid);
            });
        }
        [TestMethod]
        public void GetAllInvoices_Returns_UserInvoices()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            Guid apartmentGuid = Guid.NewGuid();

            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = apartmentGuid,
                    Bill = 30,
                    CreatedDate = DateTime.Now,
                    Description = "TestDescription",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 30,
                    Paid = 0,
                    PayDate = DateTime.Now,

                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= apartmentGuid,
                    ApartmentNumber = 20,
                    Invoices = invoices,
                }
             };

            var user = new User
            {
                Id = goodGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);

            //act
            var retList = invoiceService.GetAllInvoices(goodGuid);
            //assert
            Assert.IsTrue(retList.Count() > 0);
        }
        [TestMethod]
        public void GetInvoicesForApartment_ThrowsException_WhenUserDoesNotExist()
        {
            //arrange
            Guid badUserGuid = Guid.NewGuid();
            Guid badApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(badUserGuid)).Throws(new UserNotFoundException(badUserGuid));
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<UserNotFoundException>(() =>
            {
                invoiceService.GetInvoicesForApartment(badUserGuid, badApartmentGuid);
            });
        }
        [TestMethod]
        public void GetInvoicesForApartment_ThrowsException_WhenApartmentDoesNotExist()
        {
            //arrange
            Guid goodUserGuid = Guid.NewGuid();
            Guid goodApartmentGuid = Guid.NewGuid();
            Guid badApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= goodApartmentGuid,
                    ApartmentNumber = 20,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<ApartmentNotFoundException>(() =>
            {
                invoiceService.GetInvoicesForApartment(goodUserGuid, badApartmentGuid);
            });
        }
        [TestMethod]
        public void GetInvoicesForApartment_ThrowsException_WhenApartmentHasNoInvoice()
        {
            //arrange
            Guid goodUserGuid = Guid.NewGuid();
            Guid goodApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= goodApartmentGuid,
                    ApartmentNumber = 20,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<ApartmentHasNoInvoiceException>(() =>
            {
                invoiceService.GetInvoicesForApartment(goodUserGuid, goodApartmentGuid);
            });
        }
        [TestMethod]
        public void GetInvoicesForApartment_Returns_ApartmentInvoices()
        {
            //arrange
            Guid goodUserGuid = Guid.NewGuid();
            Guid goodApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = goodApartmentGuid,
                    Bill = 30,
                    CreatedDate = DateTime.Now,
                    Description = "TestDescription",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 30,
                    Paid = 0,
                    PayDate = DateTime.Now,
                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= goodApartmentGuid,
                    ApartmentNumber = 20,
                    Invoices = invoices,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act
            var retList = invoiceService.GetInvoicesForApartment(goodUserGuid, goodApartmentGuid);
            //assert
            Assert.IsTrue(retList.Count() > 0);
        }
        [TestMethod]
        public void GetAllOverdueInvoices_ThrowsException_WhenUserDoesNotExist()
        {
            //arrange
            Guid badGuid = Guid.NewGuid();
            DueDate dueDate = new DueDate { dueDate = "2020-05-10" };
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(badGuid)).Throws(new UserNotFoundException(badGuid));
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<UserNotFoundException>(() =>
            {
                invoiceService.GetAllOverdueInvoices(badGuid, dueDate);
            });
        }
        [TestMethod]
        public void GetAllOverdueInvoices_ThrowsException_WhenUserHasNoApartments()
        {
            //arrange
            DueDate dueDate = new DueDate { dueDate = "2020-05-10" };
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            var user = new User
            {
                Id = goodGuid,
                Email = "mail@mail.com",
                Name = "testName",
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);

            //act

            //assert
            Assert.ThrowsException<UserHasNoApartmentException>(() =>
            {
                invoiceService.GetAllOverdueInvoices(goodGuid, dueDate);
            });
        }
        [TestMethod]
        public void GetAllOverdueInvoices_ThrowsException_WhenUserHasNoInvoice()
        {
            //arrange
            DueDate dueDate = new DueDate { dueDate = "2020-05-10" };
            Guid goodUserGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= Guid.NewGuid(),
                    ApartmentNumber = 20,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<UserHasNoInvoiceException>(() =>
            {
                invoiceService.GetAllOverdueInvoices(goodUserGuid, dueDate);
            });
        }
        [TestMethod]
        public void GetAllOverdueInvoices_ThrowsException_WhenUserHasNoOverdueInvoice()
        {
            //arrange
            DueDate dueDate = new DueDate { dueDate = DateTime.Now.AddDays(-1).ToString(), };
            Guid goodUserGuid = Guid.NewGuid();
            Guid goodApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = goodApartmentGuid,
                    Bill = 30,
                    CreatedDate = DateTime.Now,
                    Description = "TestDescription",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 30,
                    Paid = 0,
                    PayDate = DateTime.Now,
                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= goodApartmentGuid,
                    ApartmentNumber = 20,
                    Invoices = invoices,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<UserHasNoOverdueInvoiceException>(() =>
            {
                invoiceService.GetAllOverdueInvoices(goodUserGuid, dueDate);
            });
        }
        [TestMethod]
        public void GetAllOverdueInvoices_Returns_OverdueInvoices()
        {
            //arrange
            DueDate dueDate = new DueDate { dueDate = DateTime.Now.AddDays(+1).ToString(), };
            Guid goodUserGuid = Guid.NewGuid();
            Guid goodApartmentGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = goodApartmentGuid,
                    Bill = 30,
                    CreatedDate = DateTime.Now,
                    Description = "TestDescription",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 30,
                    Paid = 0,
                    PayDate = DateTime.Now,
                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= goodApartmentGuid,
                    ApartmentNumber = 20,
                    Invoices = invoices,
                }
             };

            var user = new User
            {
                Id = goodUserGuid,
                Email = "mail@mail.com",
                Name = "testName",
                Apartments = apartments,
            };

            userRepositoryMock.Setup(userRepository => userRepository.GetUserByUserId(goodUserGuid)).Returns(user);

            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act
            var retList = invoiceService.GetAllOverdueInvoices(goodUserGuid, dueDate);
            //assert
            Assert.IsTrue(retList.Count() > 0);
        }
        [TestMethod]
        public void GetInvoiceByInvoiceId_ThrowsException_WhenInvoiceDoesNotExist()
        {
            //arrange
            Guid badGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetInvoiceByInvoiceId(badGuid)).Throws(new InvoiceNotFoundException(badGuid));
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<InvoiceNotFoundException>(() =>
            {
                invoiceService.GetInvoiceByInvoiceId(badGuid);
            });
        }
        [TestMethod]
        public void GetInvoiceByInvoiceId_Returns_Invoice()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            Invoice invoice = new Invoice()
            {
                Id = goodGuid,
                Bill = 100,
                ApartmentId = Guid.NewGuid(),
                Description = "TestDescription",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now,
                PayDate = DateTime.Now,
                InvoiceNumber = 20,
                Paid = 0,
            };
            invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetInvoiceByInvoiceId(goodGuid)).Returns(invoice);
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act
            var retObj = invoiceService.GetInvoiceByInvoiceId(goodGuid);
            //assert
            Assert.IsTrue(retObj != null);
        }
        [TestMethod]
        public void PayInvoice_ThrowsException_WhenInvoiceDoesNotExist()
        {
            //arrange
            Guid badGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();
            invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetInvoiceByInvoiceId(badGuid)).Throws(new InvoiceNotFoundException(badGuid));
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<InvoiceNotFoundException>(() =>
            {
                invoiceService.PayInvoice(badGuid);
            });
        }
        [TestMethod]
        public void PayInvoice_ThrowsException_WhenInvoiceIsAlreadyPaid()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            Invoice invoice = new Invoice()
            {
                Id = goodGuid,
                Bill = 100,
                ApartmentId = Guid.NewGuid(),
                Description = "TestDescription",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now,
                PayDate = DateTime.Now,
                InvoiceNumber = 20,
                Paid = 1,
            };

            invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetInvoiceByInvoiceId(goodGuid)).Returns(invoice);
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act

            //assert
            Assert.ThrowsException<InvoiceAlreadyPaidException>(() =>
            {
                invoiceService.PayInvoice(goodGuid);
            });
        }
        [TestMethod]
        public void PayInvoice_Updates_Invoice()
        {
            //arrange
            Guid goodGuid = Guid.NewGuid();
            Mock<IUserRepository> userRepositoryMock = new Mock<IUserRepository>();
            Mock<IInvoiceRepository> invoiceRepositoryMock = new Mock<IInvoiceRepository>();

            Invoice invoice = new Invoice()
            {
                Id = goodGuid,
                Bill = 100,
                ApartmentId = Guid.NewGuid(),
                Description = "TestDescription",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now,
                PayDate = DateTime.Now,
                InvoiceNumber = 20,
                Paid = 0,
            };

            invoiceRepositoryMock.Setup(invoiceRepository => invoiceRepository.GetInvoiceByInvoiceId(goodGuid)).Returns(invoice);
            InvoiceService invoiceService = new InvoiceService(userRepositoryMock.Object, invoiceRepositoryMock.Object);
            //act
            var prevPaid = invoice.Paid;
            invoiceService.PayInvoice(goodGuid);
            //assert
            Assert.IsTrue(prevPaid != invoice.Paid);
        }
    }
}
