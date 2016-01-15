using System;
using System.Configuration;
using Microsoft.Framework.Configuration;
using OrmDemo.Models;
using OrmDemo.Interfaces;
using OrmDemo.Classes.Repositories;
using Massive;

namespace OrmDemo.Classes.Simple.Data
{
    public class ContactRepository : IContactRepository
    {
        private DynamicModel table;

        public ContactRepository(IConnectionStringProvider connectionStringProvider)
        {
            table = new DynamicModel("Data:DefaultConnection:OrmDemoDb", tableName: "Contacts", primaryKeyField: "Id",
                connectionStringProvider: connectionStringProvider);
        }

        public OperationResult<Contact> AddContact(Contact contact)
        {
            var result = new OperationResult<Contact>();
            table.Insert(contact);
            return result;
        }

        public OperationResult<Guid> DeleteContact(Guid id)
        {
            throw new NotImplementedException();
        }

        public OperationResult<Contact> GetContact(Guid id)
        {
            var result = new OperationResult<Contact>();
            return result;
        }

        public OperationResult<Contact[]> GetContacts()
        {
            var contacts = table.All();
            return null;
        }

        public OperationResult<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
