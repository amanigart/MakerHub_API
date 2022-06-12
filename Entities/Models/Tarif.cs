using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Tarif
    {
        public int IdTarif { get; set; }
        public double Prix { get; set; }
        public string Duree { get; set; }
    }
}
