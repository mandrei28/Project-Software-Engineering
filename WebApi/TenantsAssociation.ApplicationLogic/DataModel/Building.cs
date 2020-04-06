using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Building
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public int StreetNumber { get; set; }
        public string BuildingNumber { get; set; }
    }
}
