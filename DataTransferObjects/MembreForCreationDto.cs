using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreForCreationDto
    {
        public DateTime DateInscription { get; init; }
        public string? Photo { get; init; }
        public string Sexe { get; init; }
        public DateTime DateNaissance { get; init; }
        public string GroupeSanguin { get; init; }
        public bool AutoriseImage { get; init; }
        public int BasePresencesRequises { get; init; }
        public int BasePresencesTotal { get; init; }
        public PersonneForCreationDto Personne { get; init; }
        public AdresseForCreationDto Adresse { get; init; }
        // public xxx Ceintures { get; init; }
        public ContactForCreationDto Contact { get; init; }
        public ReferentForCreationDto Referent { get; init; }
        public CotisationForCreationDto Cotisation { get; init; }
    }
}
