using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IV_CotisationsRepository
    {
        IEnumerable<V_Cotisations> GetAll();
        IEnumerable<V_Cotisations> GetAllByMember(int id);
        V_Cotisations GetById(int id);
    }
}
