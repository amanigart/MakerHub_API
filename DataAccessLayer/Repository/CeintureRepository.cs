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
    public sealed class CeintureRepository : RepositoryBase, IRepositoryBase<Ceinture>
    {
        public CeintureRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Ceinture ceinture)
        {
            Command cmd = new Command("RegisterCeinture", true);
            cmd.AddParameter("couleur", ceinture.Couleur);
            cmd.AddParameter("nbPresences", ceinture.nbPresencesRequis);
            cmd.AddParameter("idDiscipline", ceinture.IdDiscipline);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Ceinture WHERE idCeinture = @idCeinture";
            Command cmd = new Command(query);
            cmd.AddParameter("idCeinture", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Ceinture> GetAll()
        {
            string query = "SELECT * FROM Ceinture";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Ceinture>(cmd);
        }

        public Ceinture GetById(int id)
        {
            string query = "SELECT * FROM Ceinture WHERE idCeinture = @idCeinture";
            Command cmd = new Command(query);
            cmd.AddParameter("idCeinture", id);

            return _connection.ExecuteReader<Ceinture>(cmd).SingleOrDefault();
        }

        public void Update(Ceinture ceinture)
        {
            Command cmd = new Command("UpdateCeinture", true);
            cmd.AddParameter("idCeinture", ceinture.IdCeinture);
            cmd.AddParameter("couleur", ceinture.Couleur);
            cmd.AddParameter("nbPresences", ceinture.nbPresencesRequis);
            cmd.AddParameter("idDiscipline", ceinture.IdDiscipline);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
