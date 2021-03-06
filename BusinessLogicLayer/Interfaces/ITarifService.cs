using DataTransferObjects;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Interfaces
{
    public interface ITarifService
    {
        IEnumerable<Tarif> GetAllTarifs();
        Tarif GetTarifById(int id);
        void UpdateTarif(TarifDto pricePlan);
    }
}
