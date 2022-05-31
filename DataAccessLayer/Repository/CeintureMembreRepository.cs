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
    public sealed class CeintureMembreRepository : RepositoryBase, ICeintureMembreRepository
    {
        public CeintureMembreRepository(IConfiguration config) 
            : base(config)
        { }

        // Méthode qui enregistre une nouvelle ceinture obtenue par un membre
        public int Create(CeintureMembre ceinture)
        {
            Command cmd = new Command("RegisterCeintureMembre", true);
            cmd.AddParameter("idMembre", ceinture.IdMembre);
            cmd.AddParameter("idCeinture", ceinture.IdCeinture);

            return (int)_connection.ExecuteScalar(cmd);
        }

        // Méthode qui retourne toutes les ceintures obtenues dans une couleur spécifique
        public IEnumerable<CeintureMembre> GetAllByIdCeinture(int id)
        {
            string query = "SELECT * FROM CeintureMembre WHERE idCeinture = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<CeintureMembre>(cmd);
        }

        // Méthode qui retourne toutes les ceintures obtenues par un membre
        public IEnumerable<CeintureMembre> GetAllByIdMembre(int id)
        {
            string query = "SELECT * FROM CeintureMembre WHERE idMembre = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<CeintureMembre>(cmd);
        }

        // Méthode qui retourne une ceinture obtenue par un membre
        public CeintureMembre GetOne(int idCeinture, int idMembre)
        {
            string query = "SELECT * FROM CeintureMembre WHERE idMembre = @idMembre AND idCeinture = @idCeinture";
            Command cmd = new Command(query);
            cmd.AddParameter("idMembre", idMembre);
            cmd.AddParameter("idCeinture", idCeinture);

            return _connection.ExecuteReader<CeintureMembre>(cmd).SingleOrDefault();
        }
    }
}
