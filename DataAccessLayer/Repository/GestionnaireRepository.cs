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

        public IEnumerable<Gestionnaire> GetAll()
        {
            throw new NotImplementedException();
        }

        public Gestionnaire? GetById(int id)
        {
            Command cmd = new Command("GetGestionnaireById", true);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Gestionnaire>(cmd).SingleOrDefault();
        }

        public void Create(Gestionnaire gestionnaire)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Gestionnaire gestionnaire)
        {
            throw new NotImplementedException();
        }

        public void Delete(int entity)
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
