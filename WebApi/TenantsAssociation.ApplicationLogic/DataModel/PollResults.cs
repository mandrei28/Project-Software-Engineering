using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.DataModel
{
    public class PollResults
    {
        public Guid Id { get; set; }
        public Poll Poll { get; set; }
        public string Answer { get; set; }
    }
}
