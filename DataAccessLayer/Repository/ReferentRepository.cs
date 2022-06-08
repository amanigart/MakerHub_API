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
    public sealed class ReferentRepository : RepositoryBase, IRepositoryBase<Referent>
    {
        public ReferentRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Referent referent)
        {
            Command cmd = new Command("RegisterReferent", true);
            cmd.AddParameter("idMembre", referent.IdMembre);
            cmd.AddParameter("idReferent", referent.IdReferent);
            cmd.AddParameter("lienAvecMembre", referent.LienAvecMembre);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Referent WHERE id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Referent> GetAll()
        {
            string query = "SELECT * FROM Referent";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Referent>(cmd);
        }

        public Referent GetById(int idMembre)
        {
            string query = "SELECT * FROM Referent WHERE idMembre = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", idMembre);

            return _connection.ExecuteReader<Referent>(cmd).SingleOrDefault();

        }

        public void Update(Referent referent)
        {
            Command cmd = new Command("UpdateReferent", true);
            cmd.AddParameter("id", referent.Id);
            cmd.AddParameter("idMembre", referent.IdMembre);
            cmd.AddParameter("idReferent", referent.IdReferent);
            cmd.AddParameter("lienAvecMembre", referent.LienAvecMembre);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
