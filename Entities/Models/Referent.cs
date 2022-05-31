using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Referent
    {
        public int Id { get; set; }
        public int IdMembre { get; set; }
        public int IdReferent { get; set; }
        public string LienAvecMembre { get; set; }
    }
}
