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
    public sealed class DisciplineRepository : RepositoryBase, IDisciplineRepository
    {
        public DisciplineRepository(IConfiguration config) 
            : base(config)
        { }

        public IEnumerable<Discipline> GetAll()
        {
            string query = "SELECT * FROM Discipline";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Discipline>(cmd);
        }

        public Discipline GetById(int id)
        {
            string query = "SELECT * FROM Discipline WHERE idDiscipline = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Discipline>(cmd).SingleOrDefault();
        }
    }
}
