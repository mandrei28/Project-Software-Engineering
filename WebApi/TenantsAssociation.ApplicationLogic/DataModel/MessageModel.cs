using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class MessageModel
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
