using OrmDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrmDemo.Interfaces
{
    public interface IContactRepository
    {
        OperationResult<Contact> AddContact(Contact contact);
        OperationResult<Guid> DeleteContact(Guid id);
        OperationResult<Contact[]> GetContacts();
        OperationResult<Contact> GetContact(Guid id);
        OperationResult<Contact> UpdateContact(Contact contact);
    }
}
