using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public sealed class Presence
    {
        public int IdPresence { get; set; }
        public int IdMembre { get; set; }
        public int IdEntrainement { get; set; }
    }
}
