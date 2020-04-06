using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Apartment
    {
        public Guid Id { get; set; }
        public int ApartmentNumber { get; set; }
        public User User { get; set; }
        public Building Building { get; set; }
    }
}
