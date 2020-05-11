using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class User
    {
        public User()
        {
            Apartments = new List<Apartment>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<MessageModel> Messages { get; set; }

        public IEnumerable<Invoice> GetInvoices()
        {
            var invoiceList = new List<Invoice>();
            if (!Apartments.Any())
                throw new UserHasNoApartmentException();
            foreach (var apartment in Apartments)
            {
                invoiceList.AddRange(apartment.Invoices);
            }
            if (!invoiceList.Any())
            {
                throw new UserHasNoInvoiceException();
            }
            return invoiceList.AsEnumerable();
        }
        public IEnumerable<Invoice> GetInvoicesForApartment(Guid apartmentId)
        {
            var apartment = Apartments.Where(a => a.Id == apartmentId).FirstOrDefault();
            if (apartment == null)
            {
                throw new ApartmentNotFoundException(apartmentId);
            }
            if (!apartment.Invoices.Any())
            {
                throw new ApartmentHasNoInvoiceException(apartmentId);
            }
            return apartment.Invoices.AsEnumerable();
        }
        public IEnumerable<Invoice> GetOverdueInvoices(DueDate dueDate)
        {
            var invoiceList = new List<Invoice>();
            if (!Apartments.Any())
                throw new UserHasNoApartmentException();
            foreach (var apartment in Apartments)
            {
                invoiceList.AddRange(apartment.Invoices);
            }
            if (!invoiceList.Any())
            {
                throw new UserHasNoInvoiceException();
            }
            var date = DateTime.Parse(dueDate.dueDate);

            var overdueInvoiceList = invoiceList.Where(i => DateTime.Compare(i.DueDate, date) < 0).AsEnumerable();

            if (!overdueInvoiceList.Any())
            {
                throw new UserHasNoOverdueInvoiceException();
            }

            return overdueInvoiceList;
        }

    }
}
