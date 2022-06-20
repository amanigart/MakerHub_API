using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICotisationRepository : IRepositoryBase<Cotisation>
    {
        void UpdateArchiveStatus(int idCotisation);
        void UpdatePaymentStatus(int idCotisation);
    }
}
