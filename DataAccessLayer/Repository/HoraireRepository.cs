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
    public sealed class HoraireRepository : RepositoryBase, IHoraireRepository
    {
        public HoraireRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Horaire horaire)
        {
            Command cmd = new Command("RegisterHoraire", true);
            cmd.AddParameter("jour", horaire.Jour);
            cmd.AddParameter("heureDebut", horaire.HeureDebut);
            cmd.AddParameter("heureFin", horaire.HeureFin);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Horaire WHERE idHoraire = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Horaire> GetAll()
        {
            string query = "SELECT * FROM Horaire";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Horaire>(cmd);
        }

        public Horaire GetByDay(string day)
        {
            string query = "SELECT * FROM Horaire WHERE jour = @jour";
            Command cmd = new Command(query);
            cmd.AddParameter("jour", day);

            return _connection.ExecuteReader<Horaire>(cmd).SingleOrDefault();
        }

        public Horaire GetById(int id)
        {
            string query = "SELECT * FROM Horaire WHERE idHoraire = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Horaire>(cmd).SingleOrDefault();
        }

        public void Update(Horaire horaire)
        {
            Command cmd = new Command("UpdateHoraire", true);
            cmd.AddParameter("idHoraire", horaire.IdHoraire);
            cmd.AddParameter("jour", horaire.Jour);
            cmd.AddParameter("heureDebut", horaire.HeureDebut);
            cmd.AddParameter("heureFin", horaire.HeureFin);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
