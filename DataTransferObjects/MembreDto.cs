using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreDto
    {
        public int IdMembre { get; init; }
        public DateTime DateInscription { get; init; }
        public bool EstActif { get; init; }
        public string? Photo { get; init; }
        public string Sexe { get; init; }
        public DateTime DateNaissance { get; init; }
        public string? GroupeSanguin { get; init; }
        public bool AutoriseImage { get; init; }
        public int BasePresencesRequises { get; init; }
        public int BasePresencesTotal { get; init; }
        public Personne Personne { get; init; }
        public Adresse? Adresse { get; init; }
        public IEnumerable<V_Ceinture> Ceintures { get; init; }
        public ContactDto Contact { get; init; }
        public ReferentDto? Referent { get; init; }
        public IEnumerable<V_Cotisations>? Cotisations { get; init; }
    }
}
