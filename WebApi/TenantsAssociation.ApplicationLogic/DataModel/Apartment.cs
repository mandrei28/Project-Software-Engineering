using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Apartment
    {
        public Apartment()
        {
            Invoices = new List<Invoice>();
        }
        public Guid Id { get; set; }
        public int ApartmentNumber { get; set; }
        public Building Building { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public Guid UserId { get; set; }
    }
}
