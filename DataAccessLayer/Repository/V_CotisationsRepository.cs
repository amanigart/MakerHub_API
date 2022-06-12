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
    public sealed class V_CotisationsRepository : RepositoryBase, IV_CotisationsRepository
    {
        public V_CotisationsRepository(IConfiguration config) 
            : base(config)
        { }

        // Récupère toutes les entrées de la Vue Cotisations
        public IEnumerable<V_Cotisations> GetAll()
        {
            string query = "SELECT * FROM V_Cotisations";
            Command cmd = new(query);

            return _connection.ExecuteReader<V_Cotisations>(cmd);
        }

        // Récupère toutes les cotisations détailles sur base de l'id d'un membre (idMembre)
        public IEnumerable<V_Cotisations> GetAllByMember(int id)
        {
            string query = "SELECT * FROM V_Cotisations WHERE idMembre = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<V_Cotisations>(cmd);
        }

        // Récupère une cotisation sur base de son id (idCotisation)
        public V_Cotisations GetById(int id)
        {
            string query = "SELECT * FROM V_Cotisations WHERE idCotisation = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<V_Cotisations>(cmd).SingleOrDefault();
        }
    }
}
