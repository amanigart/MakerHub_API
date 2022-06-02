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
    public sealed class TopCeintureRepository : RepositoryBase, ITopCeintureRepository
    {
        public TopCeintureRepository(IConfiguration config) 
            : base(config)
        { }

        public IEnumerable<TopCeinture>GetTopCeintures()
        {
            string query = "SELECT * FROM V_TopCeintures";
            Command cmd = new(query);

            return _connection.ExecuteReader<TopCeinture>(cmd);
        }

        public IEnumerable<TopCeinture> GetTopCeinturesByMembre(int idMembre)
        {
            string query = "SELECT TOP 1 * FROM V_CeinturesJiujitsu WHERE idMembre = @id ORDER BY id DESC";
            Command cmd = new(query);
            cmd.AddParameter("id", idMembre);

            return _connection.ExecuteReader<TopCeinture>(cmd);
        }
    }
}
