using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;
using TenantsAssociation.ApplicationLogic.DataModel;

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
    }
}
