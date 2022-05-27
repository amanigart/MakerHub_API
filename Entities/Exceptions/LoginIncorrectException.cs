using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class LoginIncorrectException : IncorrectException
    {
        public LoginIncorrectException()
            : base("Erreur! Le login est incorrect.") 
        { }
    }
}
