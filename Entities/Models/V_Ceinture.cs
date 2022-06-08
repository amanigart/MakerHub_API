using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class V_Ceinture
    {
        public int Id { get; set; }
        public int IdMembre { get; set; }
        public string Discipline { get; set; }
        public string Couleur { get; set; }
    }
}
