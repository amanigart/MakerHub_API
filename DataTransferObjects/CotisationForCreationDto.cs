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
        public int IdTarif { get; init; }
    }
}
