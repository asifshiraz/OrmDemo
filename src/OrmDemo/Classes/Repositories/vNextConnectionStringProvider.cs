using Microsoft.Framework.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrmDemo.Classes.Repositories
{
    public class vNextConnectionStringProvider : Massive.IConnectionStringProvider
    {
        private IConfiguration configuration;

        public vNextConnectionStringProvider(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetConnectionString(string connectionStringName)
        {
            //ignore name for now
            return this.configuration[connectionStringName];
        }

        public string GetProviderName(string connectionStringName)
        {
            return null;
        }
    }
}
