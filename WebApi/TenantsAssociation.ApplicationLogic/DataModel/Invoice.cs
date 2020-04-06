using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Apartment Apartment { get; set; }
        public float Bill { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime PayDate { get; set; }
    }
}
