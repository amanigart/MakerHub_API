using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class ContactForCreationDto
    {
        public PersonneForCreationDto Personne { get; init; }
        public string LienAvecMembre { get; init; }
    }
}
