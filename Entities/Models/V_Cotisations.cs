using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class V_Cotisations
    {
        public int IdCotisation { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public bool EstPaye { get; set; }
        public bool EstArchive { get; set; }
        public int IdMembre { get; set; }
        public int IdTarif { get; set; }
        public double Prix { get; set; }
        public string Duree { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }

    }
}
