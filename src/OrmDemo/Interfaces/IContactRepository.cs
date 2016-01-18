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
        OperationResult<int> DeleteContact(int id);
        OperationResult<Contact[]> GetContacts();
        OperationResult<Contact> GetContact(int id);
        OperationResult<int> UpdateContact(Contact contact);
    }
}
