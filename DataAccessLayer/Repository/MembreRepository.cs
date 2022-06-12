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
    public sealed class MembreRepository : RepositoryBase, IRepositoryBase<Membre>
    {
        public MembreRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Membre member)
        {
            Command cmd = new Command("RegisterMembre", true);
            cmd.AddParameter("dateInscription", member.DateInscription);
            cmd.AddParameter("sexe", member.Sexe);
            cmd.AddParameter("dateNaiss", member.DateNaissance);
            cmd.AddParameter("groupeSanguin", member.GroupeSanguin);
            cmd.AddParameter("autoriseImage", member.AutoriseImage);
            cmd.AddParameter("presences", member.BasePresencesRequises);
            cmd.AddParameter("presencesTotal", member.BasePresencesTotal);
            cmd.AddParameter("idPersonne", member.IdPersonne);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Membre WHERE idMembre = @idMembre";
            Command cmd = new Command(query);
            cmd.AddParameter("idMembre", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Membre> GetAll()
        {
            string query = "SELECT * FROM Membre";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Membre>(cmd);
        }

        //public async Task<IEnumerable<Membre>> GetAllAsync() 
        //{
        //    string query = "SELECT * FROM Membre";
        //    Command cmd = new Command(query);

        //    List<Membre> members = new();

        //    await foreach(var member in _connection.ExecuteReaderAsync<Membre>(cmd))
        //        members.Add(member);

        //    return members;
        //}

        public Membre GetById(int id)
        {
            string query = "SELECT * FROM Membre WHERE idMembre = @idMembre";
            Command cmd = new Command(query);
            cmd.AddParameter("idMembre", id);

            return _connection.ExecuteReader<Membre>(cmd).SingleOrDefault();
        }

        public void Update(Membre member)
        {
            Command cmd = new Command("UpdateMembre", true);
            cmd.AddParameter("idMembre", member.IdMembre);
            cmd.AddParameter("dateInscription", member.DateInscription);
            cmd.AddParameter("sexe", member.Sexe);
            cmd.AddParameter("dateNaiss", member.DateNaissance);
            cmd.AddParameter("groupeSanguin", member.GroupeSanguin);
            cmd.AddParameter("autoriseImage", member.AutoriseImage);
            cmd.AddParameter("presences", member.BasePresencesRequises);
            cmd.AddParameter("presencesTotal", member.BasePresencesTotal);
            cmd.AddParameter("idPersonne", member.IdPersonne);

            _connection.ExecuteNonQuery(cmd);

        }
    }
}
