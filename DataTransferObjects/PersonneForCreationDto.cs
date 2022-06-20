using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjects
{
    public sealed class PersonneForCreationDto
    {
        public string? Nom { get; init; }
        public string? Prenom { get; init; }
        public string? Telephone { get; init; }
        public string? Email { get; init; }
    }
}
