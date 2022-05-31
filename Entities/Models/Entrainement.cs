using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Entrainement
    {
        public int IdEntrainement { get; set; }
        public DateTime DateEntrainement { get; set; }
        public int IdGestionnaire { get; set; }
        public int? IdHoraire { get; set; }
    }
}
