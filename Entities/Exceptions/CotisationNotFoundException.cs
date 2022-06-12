using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CotisationNotFoundException : NotFoundException
    {
        public CotisationNotFoundException() 
            : base("Aucune cotisation trouvée.")
        { }
    }
}
