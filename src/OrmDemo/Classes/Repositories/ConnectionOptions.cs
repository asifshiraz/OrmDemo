using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrmDemo.Classes.Repositories
{
    public class ConnectionOptions
    {
        public string ConnectionString { get; set; }
        public string ProviderName { get; set; }
    }
}
