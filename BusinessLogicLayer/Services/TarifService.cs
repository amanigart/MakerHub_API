using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
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
        private readonly IMapper _mapper;

        public TarifService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Récupère la liste de toutes les formules tarifaires
        public IEnumerable<Tarif> GetAllTarifs()
        {
            return _repository.Tarif.GetAll();
        }

        // Récupère un tarif sur base de son id (idTarif)
        public Tarif GetTarifById(int id)
        {
            var pricePlan = _repository.Tarif.GetById(id);
            if (pricePlan is null)
                throw new TarifNotFoundException();

            return pricePlan;
        }

        // Update un tarif
        public void UpdateTarif(TarifDto pricePlanDto)
        {
            var pricePlan = _mapper.Map<Tarif>(pricePlanDto);
            _repository.Tarif.Update(pricePlan);
        }
    }
}
