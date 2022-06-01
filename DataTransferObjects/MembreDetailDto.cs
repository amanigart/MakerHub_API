using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreDetailDto
    {
        public int IdMembre { get; init; }
        public string Sexe { get; init; }
        public string DateNaissance { get; init; }
        public string? GroupeSanguin { get; init; }
        public bool AutoriseImage { get; init; }
        public int BasePresences { get; init; }
        public string Ceinture { get; init; }
        public Personne Personne { get; init; }
        public Adresse Adresse { get; init; }
    }
}
