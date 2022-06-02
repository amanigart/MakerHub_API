using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Ceinture
    {
        public int IdCeinture { get; set; }
        public string Couleur { get; set; }
        public string? Illustration { get; set; }
        public int nbPresencesRequis { get; set; }
        public int IdDiscipline { get; set; }
    }
}
