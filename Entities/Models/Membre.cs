using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Membre
    {
        public int IdMembre { get; set; }
        public string? Photo { get; set; }
        public string Sexe { get; set; }
        public DateTime DateNaissance { get; set; }
        public string? GroupeSanguin { get; set; }
        public bool AutoriseImage { get; set; }
        public int BasePresences { get; set; }
        public bool EstActif { get; set; }
        public int IdPersonne { get; set; }
        public int? IdUtilisateur { get; set; }
    }
}
