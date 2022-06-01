using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreBasicDto
    {
        public int IdMembre { get; init; }
        public string Nom { get; init; }
        public string Prenom { get; init; }
    }
}
