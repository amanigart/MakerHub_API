using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Contact
    {
        public int Id { get; set; }
        public int IdMembre { get; set; }
        public int IdContact { get; set; }
        public string LienAvecMembre { get; set; }
    }
}
