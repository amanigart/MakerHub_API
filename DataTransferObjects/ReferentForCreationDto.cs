using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class ReferentForCreationDto
    {
        public PersonneForCreationDto? Personne { get; init; }
        public AdresseForCreationDto? Adresse { get; init; }
        public string? LienAvecMembre { get; init; }
    }
}
