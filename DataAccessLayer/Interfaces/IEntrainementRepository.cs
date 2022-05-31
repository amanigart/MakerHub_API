using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IEntrainementRepository : IRepositoryBase<Entrainement>
    {
        Entrainement GetByDate(DateTime date);
    }
}
