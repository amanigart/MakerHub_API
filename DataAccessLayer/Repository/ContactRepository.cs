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
    public sealed class ContactRepository : RepositoryBase, IRepositoryBase<Contact>
    {
        public ContactRepository(IConfiguration config) 
            : base(config)
        { }

        public int Create(Contact contact)
        {
            Command cmd = new Command("RegisterContact", true);
            cmd.AddParameter("idMembre", contact.IdMembre);
            cmd.AddParameter("idContact", contact.IdContact);
            cmd.AddParameter("lienAvecMembre", contact.LienAvecMembre);

            return (int)_connection.ExecuteScalar(cmd);
        }

        public void Delete(int id)
        {
            string query = "DELETE FROM Contact WHERE id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            _connection.ExecuteNonQuery(cmd);
        }

        public IEnumerable<Contact> GetAll()
        {
            string query = "SELECT * FROM Contact";
            Command cmd = new Command(query);

            return _connection.ExecuteReader<Contact>(cmd);
        }

        public Contact GetById(int id)
        {
            string query = "SELECT * FROM Contact WHERE id = @id";
            Command cmd = new Command(query);
            cmd.AddParameter("id", id);

            return _connection.ExecuteReader<Contact>(cmd).SingleOrDefault();
        }

        public void Update(Contact contact)
        {
            Command cmd = new Command("UpdateContact", true);
            cmd.AddParameter("id", contact.Id);
            cmd.AddParameter("idMembre", contact.IdMembre);
            cmd.AddParameter("idContact", contact.IdContact);
            cmd.AddParameter("lienAvecMembre", contact.LienAvecMembre);

            _connection.ExecuteNonQuery(cmd);
        }
    }
}
