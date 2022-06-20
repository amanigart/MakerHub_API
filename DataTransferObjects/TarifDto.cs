using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class TarifDto
    {
        public int IdTarif { get; init; }
        public double Prix { get; init; }
        public string Duree { get; init; }
    }
}
