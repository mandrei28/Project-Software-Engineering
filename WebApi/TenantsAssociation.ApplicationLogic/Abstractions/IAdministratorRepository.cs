using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.DataModel;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IAdministratorRepository 
    {
        MessageModel GetLastMessage(Guid id);
        void CreatePoll(Poll poll);
    }
}
