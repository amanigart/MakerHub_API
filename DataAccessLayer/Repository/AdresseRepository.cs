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
    public sealed class AdresseRepository : RepositoryBase, IRepositoryBase<Adresse>
    {
        private readonly IRepositoryManager _repo;
        public AdresseRepository(IConfiguration config)
            : base(config)
        { }

        // Enregistre une adresse et retourne l'idAdresse généré
        public int Create(Adresse adresse)
        {
            Command cmd = new Command("RegisterAdresse", true);
            cmd.AddParameter("rue", adresse.Rue);
            cmd.AddParameter("numero",adresse.Numero);
            cmd.AddParameter("cp", adresse.CodePostal);
            cmd.AddParameter("ville", adresse.Ville);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Adresse WHERE idAdresse = @idAdresse";
            Command cmd = new Command(query);
            cmd.AddParameter("idAdresse", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Adresse> GetAll()
        {
            string query = "SELECT * FROM Adresse";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Adresse>(cmd);
        }

        public Adresse GetById(int id)
        {
            string query = "SELECT * FROM Adresse WHERE idAdresse = @idAdresse";
            Command cmd = new Command(query);
            cmd.AddParameter("idAdresse", id);

            return _connection.ExecuteReader<Adresse>(cmd).SingleOrDefault();
        }

        public void Update(Adresse adresse)
        {
            Command cmd = new Command("UpdateAdresse", true);
            cmd.AddParameter("idAdresse", adresse.IdAdresse);
            cmd.AddParameter("rue", adresse.Rue);
            cmd.AddParameter("numero", adresse.Numero);
            cmd.AddParameter("cp", adresse.CodePostal);
            cmd.AddParameter("ville", adresse.Ville);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
