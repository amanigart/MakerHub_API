using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ICotisationService
    {
        IEnumerable<CotisationDto> GetAllCotisations();
        void CreateCotisationForMember(CotisationForCreationDto membership);
        void SwitchArchiveStatus(int idCotisation);
        void SwitchPaymentStatus(int idCotisation);
    }
}
