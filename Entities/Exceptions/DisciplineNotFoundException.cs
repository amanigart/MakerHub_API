using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class DisciplineNotFoundException : NotFoundException
    {
        public DisciplineNotFoundException() 
            : base("Cette discipline n'existe pas.")
        { }
    }
}
