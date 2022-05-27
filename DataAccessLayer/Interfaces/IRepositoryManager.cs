using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryManager
    {
        IAuthenticationRepository Authentication { get; }
        IGestionnaireRepository Gestionnaire { get; }
    }
}
