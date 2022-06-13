using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using Entities.Exceptions;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class TarifService : ITarifService
    {
        private readonly IRepositoryManager _repository;

        public TarifService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        // Récupère la liste de toutes les formules tarifaires
        public IEnumerable<Tarif> GetAllTarifs()
        {
            return _repository.Tarif.GetAll();
        }

        // Récupère un tarif sur base de son id (idTarif)
        public Tarif GetTarifById(int id)
        {
            Tarif pricePlan = _repository.Tarif.GetById(id);
            if (pricePlan is null)
                throw new TarifNotFoundException();

            return pricePlan;
        }
    }
}
