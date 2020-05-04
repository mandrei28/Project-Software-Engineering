using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;
using TenantsAssociation.ApplicationLogic.DtoModels;

namespace TenantsAssociation.ApplicationLogic.Services
{
    public class InvoiceService
    {
        private readonly IUserRepository userRepository;
        public InvoiceService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
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
        public IEnumerable<Invoice> GetAllOverdueInvoices(Guid userId,DueDate dueDate)
        {
            var currentUser = userRepository.GetUserByUserId(userId);
            return currentUser.GetOverdueInvoices(dueDate);
        }

    }
}
