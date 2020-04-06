using System;
using System.Collections.Generic;
using System.Text;
using TenantsAssociation.ApplicationLogic.Abstractions;

namespace TenantsAssociation.DataAccess
{
    public class BaseRepository<T> : IRepository<T>
    {
        public T Add(T itemToAdd)
        {
            throw new NotImplementedException();
        }

        public bool Delete(T itemToDelete)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Update(T itemToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
