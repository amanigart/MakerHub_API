using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class TarifNotFoundException : NotFoundException
    {
        public TarifNotFoundException() 
            : base("Ce tarif n'existe pas.")
        { }
    }
}
