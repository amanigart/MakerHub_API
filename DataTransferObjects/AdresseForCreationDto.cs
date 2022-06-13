using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class AdresseForCreationDto
    {
        public string Rue { get; init; }
        public string Numero { get; init; }
        public int CodePostal { get; init; }
        public string Ville { get; init; }
    }
}
