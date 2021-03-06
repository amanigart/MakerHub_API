using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IServiceManager
    {
        IAuthenticationService Authentication { get; }
        IMembreService Membre { get; }
        IDisciplineService Discipline { get; }
        ICeintureService Ceinture { get; }
        IHoraireService Horaire { get; }
        ITarifService Tarif { get; }
        ICotisationService Cotisation { get; }
    }
}
