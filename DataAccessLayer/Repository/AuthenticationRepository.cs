using AdoToolbox;
using DataAccessLayer.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public sealed class AuthenticationRepository : RepositoryBase, IAuthenticationRepository
    {
        public AuthenticationRepository(IConfiguration config) 
            : base(config) 
        { }

        public AppUtilisateur Login(string login, string passwd)
        {
            try
            {
                Command cmd = new Command("Login", true);
                cmd.AddParameter("login", login);
                cmd.AddParameter("passwd", passwd);

                return _connection.ExecuteReader<AppUtilisateur>(cmd).SingleOrDefault();  // null check en db
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 51000: throw new LoginIncorrectException();
                    case 51001: throw new PasswordIncorrectException();
                    default: throw new Exception(ex.Message);
                }
            }
        }
    }
}