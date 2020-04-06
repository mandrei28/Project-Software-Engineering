using System;
using System.Collections.Generic;
using System.Text;

namespace TenantsAssociation.ApplicationLogic.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Add(T itemToAdd);
        T Update(T itemToUpdate);
        bool Delete(T itemToDelete);
    }
}
