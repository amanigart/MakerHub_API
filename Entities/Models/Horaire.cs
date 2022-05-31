using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Horaire
    {
        public int IdHoraire { get; set; }
        public string Jour { get; set; }
        public string HeureDebut { get; set; }
        public string HeureFin { get; set; }
    }
}
