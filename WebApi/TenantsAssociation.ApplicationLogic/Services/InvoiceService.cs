using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;
using TenantsAssociation.ApplicationLogic.Exceptions;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class InvoiceService
    {
        private readonly IUserRepository userRepository;
        private readonly IInvoiceRepository invoiceRepository;
        public InvoiceService(IUserRepository userRepository, IInvoiceRepository invoiceRepository)
        {
            this.userRepository = userRepository;
            this.invoiceRepository = invoiceRepository;
        }
        public IEnumerable<Invoice> GetAllInvoices(Guid userId)
        {
            var currentUser = userRepository.GetUserByUserId(userId);
            return currentUser.GetInvoices();
        }
        public IEnumerable<Invoice> GetInvoicesForApartment(Guid userId, Guid apartmentId)
        {
            var currentUser = userRepository.GetUserByUserId(userId);
            return currentUser.GetInvoicesForApartment(apartmentId);
        }
        public IEnumerable<Invoice> GetAllOverdueInvoices(Guid userId, DueDate dueDate)
        {
            var currentUser = userRepository.GetUserByUserId(userId);
            return currentUser.GetOverdueInvoices(dueDate);
        }
        public Invoice GetInvoiceByInvoiceId(Guid invoiceId)
        {
            return invoiceRepository.GetInvoiceByInvoiceId(invoiceId);
        }
        public void PayInvoice(Guid invoiceId)
        {
            var invoice = invoiceRepository.GetInvoiceByInvoiceId(invoiceId);
            if (invoice.Paid == 1)
                throw new InvoiceAlreadyPaidException(invoiceId);
            invoice.Paid = 1;
            invoiceRepository.Update(invoice);
        }

    }
}
