using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public sealed class PasswordIncorrectException : IncorrectException
    {
        public PasswordIncorrectException()
            : base($"Erreur! Le mot de passe est incorrect.")
        { }
    }
}
