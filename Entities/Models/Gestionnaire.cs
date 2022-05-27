using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Gestionnaire : AppUtilisateur
    {
        public int IdGestionnaire { get; set; }
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public Gestionnaire() { }

        public Gestionnaire(int idUtilisateur, string login, int idGestionnaire, string prenom, string nom, string email, string telephone)
            : base(idUtilisateur, login)
        {
            IdGestionnaire = idGestionnaire;
            Prenom = prenom;
            Nom = nom;
            Email = email;
            Telephone = telephone;
        }
    }
}
