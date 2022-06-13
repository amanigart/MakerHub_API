using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreInfosForCreationDto
    {
        public DateTime DateInscription { get; init; }
        public string? Photo { get; init; }
        public string Sexe { get; init; }
        public DateTime DateNaissance { get; init; }
        public string GroupeSanguin { get; init; }
        public bool AutoriseImage { get; init; }
        public int BasePresencesRequises { get; init; }
        public int BasePresencesTotal { get; init; }
    }
}
