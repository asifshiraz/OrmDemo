using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace OrmDemo
{
    public class Initialize
    {
        private string ConnectionString;

        public Initialize With(string connectionString)
        {
            this.ConnectionString = connectionString;
            return this;
        }

        public Initialize CreateDatabase()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new Exception("Connection string not initialized");
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = schemaSql;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return this;
        }

        public Initialize PopulateDatabase()
        {
            if (string.IsNullOrWhiteSpace(ConnectionString))
                throw new Exception("Connection string not initialized");
            using (var con = new SqlConnection(this.ConnectionString))
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = dataSql;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return this;
        }

        #region Database Schema Sql

        private string schemaSql = @"
IF NOT EXISTS 
	(SELECT * FROM SYSOBJECTS
	WHERE name LIKE 'Contacts' AND XTYPE = 'U')
BEGIN
	CREATE TABLE [Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Dob] [datetime] NOT NULL,
	[Phone] [nvarchar](15) NOT NULL,
	 CONSTRAINT [PK_Contacts] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END
";

        private string dataSql = @"
DECLARE @ROWS int;
SELECT @ROWS = COUNT(*) FROM Contacts
IF (@ROWS = 0)
BEGIN
insert into [Contacts] ([Name], [Dob], [Phone]) values ('John Smith','02/14/1998','5129872736');
insert into [Contacts] ([Name], [Dob], [Phone]) values ('Jennifer Laurens','08/01/1997','5125345321');
insert into [Contacts] ([Name], [Dob], [Phone]) values ('Bob Dale','02/14/1998','5123482303');
insert into [Contacts] ([Name], [Dob], [Phone]) values ('Katty Allen','02/14/1998','5129021055');
END
";

        #endregion
    }
}
