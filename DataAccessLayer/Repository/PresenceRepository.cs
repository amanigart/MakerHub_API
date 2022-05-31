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
    public sealed class PresenceRepository : RepositoryBase, IPresenceRepository
    {
        public PresenceRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Presence presence)
        {
            Command cmd = new("RegisterPresence", true);
            cmd.AddParameter("idMembre", presence.IdMembre);
            cmd.AddParameter("idEntrainement", presence.IdEntrainement);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Presence WHERE idPresence = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Presence> GetAll()
        {
            string query = "SELECT * FROM Presence";
            Command cmd = new(query);

            return _connection.ExecuteReader<Presence>(cmd);
        }

        public Presence GetById(int id)
        {
            string query = "SELECT * FROM Presence WHERE idPresence = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Presence>(cmd).SingleOrDefault();
        }

        public void Update(Presence presence)
        {
            Command cmd = new("RegisterPresence", true);
            cmd.AddParameter("idPresence", presence.IdPresence);
            cmd.AddParameter("idMembre", presence.IdMembre);
            cmd.AddParameter("idEntrainement", presence.IdEntrainement);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
