using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IAuthenticationRepository
    {
        AppUtilisateur Login(string login, string passwd);
    }
}
