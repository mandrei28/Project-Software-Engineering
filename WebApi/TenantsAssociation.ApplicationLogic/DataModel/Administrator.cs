using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Administrator
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<Building> Buildings { get; set; }
    }
}
