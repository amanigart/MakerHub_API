using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class CotisationForCreationDto
    {
        public DateTime DateDebut { get; init; }
        public bool EstPaye { get; init; }
        public int IdTarif { get; init; }
        public string Duree { get; init; }
    }
}
