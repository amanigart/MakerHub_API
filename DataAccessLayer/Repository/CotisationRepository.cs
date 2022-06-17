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
    public sealed class CotisationRepository : RepositoryBase, IRepositoryBase<Cotisation>
    {
        public CotisationRepository(IConfiguration config) 
            : base(config)
        { }

        // Enregistre une nouvelle cotisation
        public int Create(Cotisation entity)
        {
            Command cmd = new("RegisterCotisation", true);
            cmd.AddParameter("dateDebut", entity.DateDebut);
            cmd.AddParameter("dateFin", entity.DateFin);
            cmd.AddParameter("estPaye", entity.EstPaye);
            cmd.AddParameter("idTarif", entity.IdTarif);
            cmd.AddParameter("idMembre", entity.IdMembre);

            return (int)_connection.ExecuteScalar(cmd);
        }

        // Soft delete (archive) une cotisation sur base de son id (idCotisation)
        public void Delete(int id)
        {
            Command cmd = new("ArchiveCotisation", true);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        // Récupère la liste de toutes les cotisations existantes
        public IEnumerable<Cotisation> GetAll()
        {
            string query = "SELECT * FROM Cotisation";
            Command cmd = new(query);

            return _connection.ExecuteReader<Cotisation>(cmd);
        }

        // Récupère la cotisation d'un membre sur base de l'id de celui-ci (idMembre)
        public Cotisation GetById(int id)
        {
            string query = "SELECT * FROM Cotisation WHERE idMembre = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Cotisation>(cmd).SingleOrDefault();
        }

        // Mise à jour d'une cotisation
        public void Update(Cotisation entity)
        {
            Command cmd = new("UpdateCotisation", true);
            cmd.AddParameter("idCotisation", entity.IdCotisation);
            cmd.AddParameter("dateDebut", entity.DateDebut);
            cmd.AddParameter("dateFin", entity.DateFin);
            cmd.AddParameter("estPaye", entity.EstPaye);
            cmd.AddParameter("estArchive", entity.EstArchive);
            cmd.AddParameter("idTarif", entity.EstPaye);
            cmd.AddParameter("idMembre", entity.IdMembre);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
