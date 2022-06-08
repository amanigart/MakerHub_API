using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class CeintureNotFoundException : NotFoundException
    {
        public CeintureNotFoundException() 
            : base("Cetteceinture n'existe pas.")
        { }
    }
}
