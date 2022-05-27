using AdoToolbox;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public abstract class RepositoryBase
    {
        internal readonly Connection _connection;
        internal readonly IConfiguration _config;
        
        public RepositoryBase(IConfiguration config)
        {
            _config = config;
            _connection = new Connection(_config.GetConnectionString("default"));
        }
    }
}
