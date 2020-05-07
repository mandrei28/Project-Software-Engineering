using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Invoice
    {
        public Guid Id { get; set; }
        public int InvoiceNumber { get; set; }
        public Guid ApartmentId { get; set; }
        public float Bill { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "Date")]
        public DateTime CreatedDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DueDate { get; set; }
        [Column(TypeName = "Date")]
        public DateTime PayDate { get; set; }
        public int Paid { get; set; }
    }
}
