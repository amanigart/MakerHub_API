using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IAuthenticationService
    {
        AppUtilisateurDto Login(string login, string passwd);
    }
}
