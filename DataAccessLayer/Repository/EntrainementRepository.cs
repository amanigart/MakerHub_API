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
    public sealed class EntrainementRepository : RepositoryBase, IEntrainementRepository
    {
        public EntrainementRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Entrainement training)
        {
            Command cmd = new("RegisterEntrainement", true);
            cmd.AddParameter("date", training.DateEntrainement);
            cmd.AddParameter("idHoraire", training.IdHoraire);
            cmd.AddParameter("idGestionnaire", training.IdGestionnaire);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Entrainement WHERE idEntrainement = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Entrainement> GetAll()
        {
            string query = "SELECT * FROM Entrainement";
            Command cmd = new(query);

            return _connection.ExecuteReader<Entrainement>(cmd);
        }

        public Entrainement GetByDate(DateTime date)
        {
            string query = "SELECT * FROM Entrainement WHERE dateEntrainement = @date";
            Command cmd = new(query);
            cmd.AddParameter("date", date);

            return _connection.ExecuteReader<Entrainement>(cmd).SingleOrDefault();
        }

        public Entrainement GetById(int id)
        {
            string query = "SELECT * FROM Entrainement WHERE idEntrainement = @id";
            Command cmd = new(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Entrainement>(cmd).SingleOrDefault();
        }

        public void Update(Entrainement training)
        {
            Command cmd = new("RegisterEntrainement", true);
            cmd.AddParameter("idEntrainement", training.IdEntrainement);
            cmd.AddParameter("date", training.DateEntrainement);
            cmd.AddParameter("idHoraire", training.IdHoraire);
            cmd.AddParameter("idGestionnaire", training.IdGestionnaire);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
