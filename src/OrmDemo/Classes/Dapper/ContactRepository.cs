using System;
using OrmDemo.Models;
using OrmDemo.Interfaces;

namespace OrmDemo.Classes.Dapper
{
    public class ContactRepository : IContactRepository
    {
        private IConnectionFactory connectionFactory;

        public ContactRepository(IConnectionFactory connectionFactory)
        {
            this.connectionFactory = connectionFactory;
        }
        public OperationResult<Contact> AddContact(Contact contact)
        {
            var result = new OperationResult<Contact>();
            using (var conn = connectionFactory.GetConnection())
            {
                conn.Open();
                //conn.Query(@"insert Contacts(Name, Dob, Phone) values (@Name, @Dob, @Phone)", contact);
                conn.Close();
                result.IsSuccessful = true;
            }
            return result;
        }

        public OperationResult<Guid> DeleteContact(Guid id)
        {
            throw new NotImplementedException();
        }

        public OperationResult<Contact> GetContact(Guid id)
        {
            var result = new OperationResult<Contact>();
            /*using (var sqlConnection = connectionFactory.GetConnection())
            {
                var cmd = new CommandDefinition("Select * from Contact where Id = @ContactId", new { ContactID = 2 });
                var c = sqlConnection.QueryFirst<Contact>(cmd);
            }*/
            return result;
        }

        public OperationResult<Contact[]> GetContacts()
        {
            throw new NotImplementedException();
        }

        public OperationResult<Contact> UpdateContact(Contact contact)
        {
            throw new NotImplementedException();
        }
    }
}
