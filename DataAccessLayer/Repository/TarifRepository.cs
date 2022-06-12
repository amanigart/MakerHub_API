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
    public sealed class TarifRepository : RepositoryBase, IRepositoryBase<Tarif>
    {
        public TarifRepository(IConfiguration config) 
            : base(config)
        { }

        // Enregistre un nouveau tarif et retourn l'id inséré (idTarif)
        public int Create(Tarif entity)
        {
            Command cmd = new Command("RegisterTarif", true);
            cmd.AddParameter("prix", entity.Prix);
            cmd.AddParameter("duree", entity.Duree);

            return (int)_connection.ExecuteScalar(cmd);
        }

        // Supprime un tarif sur base de son id
        public void Delete(int id)
        {
            string query = "DELETE FROM Tarif WHERE idTarif = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        // Récupère la liste de tous les tarifs existants
        public IEnumerable<Tarif> GetAll()
        {
            string query = "SELECT * FROM Tarif";
            Command cmd = new(query);

            return _connection.ExecuteReader<Tarif>(cmd);
        }

        // Récupère un tarif sur base de son id (idTarif)
        public Tarif GetById(int id)
        {
            string query = "SELECT * FROM Tarif WHERE idTarif = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Tarif>(cmd).SingleOrDefault();
        }

        // Mise à jour d'un tarif
        public void Update(Tarif entity)
        {
            Command cmd = new("UpdateTarif", true);
            cmd.AddParameter("id", entity.IdTarif);
            cmd.AddParameter("prix", entity.Prix);
            cmd.AddParameter("duree", entity.Duree);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
