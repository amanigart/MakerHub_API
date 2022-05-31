using AdoToolbox;
using DataAccessLayer.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public class GestionnaireRepository : RepositoryBase, IGestionnaireRepository
    {
        public GestionnaireRepository(IConfiguration config)
            : base(config) 
        { }

        public int Create(Gestionnaire gestionnaire)
        {
            Command cmd = new Command("RegisterGestionnaire", true);
            cmd.AddParameter("idMembre", gestionnaire.IdMembre);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public IEnumerable<Gestionnaire> GetAll()
        {
            string query = "SELECT * FROM Gestionnaire";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Gestionnaire>(cmd);
        }

        public Gestionnaire GetById(int id)
        {
            Command cmd = new Command("GetGestionnaireById", true);
            cmd.AddParameter("idGestionnaire", id);

            return _connection.ExecuteReader<Gestionnaire>(cmd).SingleOrDefault();
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Gestionnaire WHERE idGestionnaire = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public void Update(Gestionnaire gestionnaire)
        {
            throw new NotImplementedException();
        }

        public bool CheckIfIsGestionnaire(int id)
        {
            Command cmd = new Command("CheckIfIsGestionnaire", true);
            cmd.AddParameter("id", id);

            return (bool)_connection.ExecuteScalar(cmd);
        }
    }
}
