using AdoToolbox;
using DataAccessLayer.Interfaces;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public sealed class V_CeintureRepository : RepositoryBase, IV_CeintureRepository
    {
        public V_CeintureRepository(IConfiguration config) 
            : base(config)
        { }

        public IEnumerable<V_Ceinture>GetAll()
        {
            string query = "SELECT * FROM V_Ceintures";
            Command cmd = new(query);

            return _connection.ExecuteReader<V_Ceinture>(cmd);
        }

        public IEnumerable<V_Ceinture> GetAllByMember(int idMembre)
        {
            string query = "SELECT * FROM V_Ceintures WHERE idMembre = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", idMembre);

            return _connection.ExecuteReader<V_Ceinture>(cmd);
        }
    }
}
