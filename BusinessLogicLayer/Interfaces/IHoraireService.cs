using DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface IHoraireService
    {
        IEnumerable<Horaire> getAllHoraires();
        Horaire getHoraireById(int id);
    }
}
