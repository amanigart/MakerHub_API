using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IV_CeintureRepository
    {
        IEnumerable<V_Ceinture> GetAll();
        IEnumerable<V_Ceinture> GetAllByMember(int idMembre);
    }
}
