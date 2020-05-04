using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DtoModels
{
    public class MessageView
    {
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string AdministratorId { get; set; }
        public string Email { get; set; }
    }
}
