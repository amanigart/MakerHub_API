using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class MembreNotFoundException : NotFoundException
    {
        public MembreNotFoundException()
            : base("Ce membre n'existe pas.")
        { }
    }
}
