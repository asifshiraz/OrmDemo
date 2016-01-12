using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrmDemo.Models;
using OrmDemo.Interfaces;

namespace OrmDemo.Classes
{
    public class FakeContactRepository : IContactRepository
    {
        OperationResult<Contact> IContactRepository.AddContact(Contact contact)
        {
            throw new NotImplementedException();
        }

        OperationResult<Guid> IContactRepository.DeleteContact(Guid id)
        {
            throw new NotImplementedException();
        }

        OperationResult<Contact> IContactRepository.GetContact(Guid id)
        {
            throw new NotImplementedException();
        }

        OperationResult<Contact[]> IContactRepository.GetContacts()
        {
            throw new NotImplementedException();
        }

        OperationResult<Contact> IContactRepository.UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
