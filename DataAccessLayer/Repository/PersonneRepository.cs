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
    public sealed class PersonneRepository : RepositoryBase, IRepositoryBase<Personne>
    {
        public PersonneRepository(IConfiguration config) 
            : base(config)
        { }

        // Enregistre une nouvelle personne et retourne inserted.idPersonne
        public int Create(Personne personne)
        {
            Command cmd = new Command("RegisterPersonne", true);
            cmd.AddParameter("nom", personne.Nom);
            cmd.AddParameter("prenom", personne.Prenom);
            cmd.AddParameter("email", personne.Email);
            cmd.AddParameter("tel", personne.Telephone);
            cmd.AddParameter("idAdresse", personne.IdAdresse);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Personne WHERE idPersonne = @idPersonne";
            Command cmd = new Command(query);
            cmd.AddParameter("idPersonne", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Personne> GetAll()
        {
            string query = "SELECT * FROM Personne";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Personne>(cmd);
        }

        public Personne GetById(int id)
        {
            string query = "SELECT * FROM Personne WHERE idPersonne = @idPersonne";
            Command cmd = new Command(query);
            cmd.AddParameter("idPersonne", id);

            return _connection.ExecuteReader<Personne>(cmd).SingleOrDefault();
        }

        public void Update(Personne personne)
        {
            Command cmd = new Command("UpdatePersonne", true);
            cmd.AddParameter("idPersonne", personne.IdPersonne);
            cmd.AddParameter("nom", personne.Nom);
            cmd.AddParameter("prenom", personne.Prenom);
            cmd.AddParameter("email", personne.Email);
            cmd.AddParameter("tel", personne.Telephone);
            cmd.AddParameter("idAdresse", personne.IdAdresse);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
