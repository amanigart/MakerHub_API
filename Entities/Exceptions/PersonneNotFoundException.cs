using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PersonneNotFoundException : NotFoundException
    {
        public PersonneNotFoundException()
            : base($"Cette personne n'existe pas.")
        { }
    }
}
