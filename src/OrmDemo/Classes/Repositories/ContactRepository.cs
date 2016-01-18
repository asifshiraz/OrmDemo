using System;
using System.Configuration;
using System.Linq;
using Microsoft.Framework.Configuration;
using OrmDemo.Models;
using OrmDemo.Interfaces;
using OrmDemo.Classes.Repositories;
using Massive;
using System.Collections.Generic;

namespace OrmDemo.Classes.Simple.Data
{
    public class ContactRepository : IContactRepository
    {
        private DynamicModel table;

        public ContactRepository(IConnectionStringProvider connectionStringProvider)
        {
            table = new DynamicModel("ConnectionString", tableName: "Contacts", primaryKeyField: "Id",
                connectionStringProvider: connectionStringProvider);
        }

        public OperationResult<Contact> AddContact(Contact contact)
        {
            var result = new OperationResult<Contact>();
            table.Insert(contact.ForInsert());
            return result;
        }

        public OperationResult<int> DeleteContact(int id)
        {
            var result = new OperationResult<int>();
            result.Data = table.Delete(key: id);
            return result;
        }

        public OperationResult<Contact> GetContact(int id)
        {
            var result = new OperationResult<Contact>();
            var dyn = table.Single(id);
            result.Data = new Contact() { Id = dyn.Id, Dob = dyn.Dob, Name = dyn.Name, Phone = dyn.Phone };
            return result;
        }

        public OperationResult<Contact[]> GetContacts()
        {
            var result = new OperationResult<Contact[]>();
            result.Data = table.All().Select(x => new Contact() { Id = x.Id, Dob = x.Dob, Name = x.Name, Phone = x.Phone }).ToArray();
            return result;
        }
        
        public OperationResult<int> UpdateContact(Contact contact)
        {
            var result = new OperationResult<int>();
            result.Data = table.Update(contact, contact.Id);
            return result;
        }
    }
}
