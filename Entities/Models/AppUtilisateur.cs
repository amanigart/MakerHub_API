using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class AppUtilisateur
    {
        public int IdUtilisateur { get; set; }
        public string Login { get; set; }

        public AppUtilisateur() { }

        public AppUtilisateur(int idutilisateur, string login)
        {
            IdUtilisateur = idutilisateur;
            Login = login;
        }
    }
}
