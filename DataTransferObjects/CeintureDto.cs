using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class CeintureDto
    {
        public int IdCeinture { get; init; }
        public string Couleur { get; init; }
        public int NbPresencesRequis { get; init; }
        public string? Illustration { get; init; }
        public Discipline Discipline { get; init; }
    }
}
