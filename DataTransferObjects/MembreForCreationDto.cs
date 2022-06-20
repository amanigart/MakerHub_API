using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class MembreForCreationDto
    {
        public MembreInfosForCreationDto MembreInfos { get; init; }
        public PersonneForCreationDto Personne { get; init; }
        public AdresseForCreationDto Adresse { get; init; }
        public IEnumerable<CeintureMembreDto> Ceintures { get; init; }
        public ContactForCreationDto Contact { get; init; }
        public ReferentForCreationDto? Referent { get; init; }
        public CotisationForCreationDto Cotisation { get; init; }
    }
}
