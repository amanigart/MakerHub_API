using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class GestionnaireNotFoundException : NotFoundException
    {
        public GestionnaireNotFoundException()
            : base($"Le gestionnaire n'existe pas.")
        { }
    }
}
