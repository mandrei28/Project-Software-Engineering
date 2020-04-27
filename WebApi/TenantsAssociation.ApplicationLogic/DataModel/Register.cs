using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class Register
    {
        public string Username { get; set; }
        public EmailAddressAttribute Email { get; set; }
        public string Password { get; set; }
    }
}