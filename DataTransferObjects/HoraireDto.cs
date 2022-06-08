using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class HoraireDto
    {
        public int IdHoraire { get; init; }
        public string Jour { get; init; }
        public string HeureDebut { get; init; }
        public string HeureFin { get; init; }
    }
}
