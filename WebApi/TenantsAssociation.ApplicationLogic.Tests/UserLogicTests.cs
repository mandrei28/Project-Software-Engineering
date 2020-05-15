using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.Exceptions;
using TenantsAssociation.ApplicationLogic.Services;

namespace TenantsAssociation.ApplicationLogic.Tests
{
    [TestClass]
    public class UserLogicTests
    {
        [TestMethod]
        public void GetInvoices_ThrowsException_UserHasNoApartmentException()
        {
            //Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Asd@asd.com",
            };

            //Act

            //Assert            
            Assert.ThrowsException<UserHasNoApartmentException>(() => { user.GetInvoices(); });

        }

        [TestMethod]
        public void GetInvoices_ThrowsException_UserHasNoInvoiceException()
        {

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= Guid.NewGuid(),
                    ApartmentNumber = 1,
                }
            };

            //Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Asd@asd.com",
                Apartments = apartments

            };

            //Act

            //Assert            
            Assert.ThrowsException<UserHasNoInvoiceException>(() => { user.GetInvoices(); });

        }


        [TestMethod]
        public void GetInvoices_Return_Invoices()
        {
            Guid apartmentGuid = Guid.NewGuid();
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = apartmentGuid,
                    Bill = 1,
                    CreatedDate = DateTime.Now,
                    Description = "Test",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 1,
                    Paid = 0,
                    PayDate = DateTime.Now,

                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= apartmentGuid,
                    ApartmentNumber = 1,
                    Invoices = invoices
                }
            };

            //Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Asd@asd.com",
                Apartments = apartments

            };

            //Act

            //Assert            
            //Assert.IsTrue(user.GetInvoices().Count() == 1);
            CollectionAssert.AreEqual(user.GetInvoices().ToList(),invoices);
        }

        [TestMethod]
        public void GetInvoicesForApartment_Return_Invoices()
        {
            Guid apartmentGuid = Guid.NewGuid();
            List<Invoice> invoices = new List<Invoice>
            {
                new Invoice
                {
                    Id = Guid.NewGuid(),
                    ApartmentId = apartmentGuid,
                    Bill = 1,
                    CreatedDate = DateTime.Now,
                    Description = "Test",
                    DueDate = DateTime.Now,
                    InvoiceNumber = 1,
                    Paid = 0,
                    PayDate = DateTime.Now,

                }
            };

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= apartmentGuid,
                    ApartmentNumber = 1,
                    Invoices = invoices
                }
            };

            //Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Asd@asd.com",
                Apartments = apartments

            };

            //Assert            
            CollectionAssert.AreEqual(user.GetInvoicesForApartment(apartments[0].Id).ToList(), invoices);

        }

        [TestMethod]
        public void GetInvoicesForApartment_ThrowException_ApartmentNotFoundException()
        {
            Guid badGuid = Guid.NewGuid();
            //Arrange
            User user = new User();

            //Assert            
            Assert.ThrowsException<ApartmentNotFoundException>(() => user.GetInvoicesForApartment(badGuid));
        }

        [TestMethod]
        public void GetInvoicesForApartment_ThrowException_ApartmentHasNoInvoiceException()
        {
            Guid apartmentId = Guid.NewGuid();

            List<Apartment> apartments = new List<Apartment>
            {
                new Apartment
                {
                    Id= apartmentId,
                    ApartmentNumber = 1
                }
            };

            //Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                Email = "Asd@asd.com",
                Apartments = apartments

            };

            //Assert            
            Assert.ThrowsException<ApartmentHasNoInvoiceException>(() => { user.GetInvoicesForApartment(apartmentId); });

        }
    }

}