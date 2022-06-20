using AutoMapper;
using BusinessLogicLayer.Interfaces;
using BusinessLogicLayer.Tools;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class CotisationService : ICotisationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public CotisationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        // Récupère la liste de toutes les cotisations
        public IEnumerable<CotisationDto> GetAllCotisations()
        {
            IEnumerable<V_Cotisations> cotisations = _repository.V_Cotisations.GetAll();
            IEnumerable<CotisationDto> cotisationsDto = _mapper.Map<IEnumerable<CotisationDto>>(cotisations);

            return cotisationsDto;
        }

        // Enregistre une cotisation pour un membre
        public void CreateCotisationForMember(CotisationForCreationDto membership)
        {
            Cotisation newMembership = _mapper.Map<Cotisation>(membership);
            newMembership.DateFin = newMembership.DateDebut.GetCotisationEndDate(membership.Duree);

            _repository.Cotisation.Create(newMembership);
        }

        // Modifie le status d'archivage d'une cotisation sur base de son id
        public void SwitchArchiveStatus(int idCotisation)
        {
            _repository.Cotisation.UpdateArchiveStatus(idCotisation);
        }

        // Modifie le status du paiement d'une cotisation sur base de son id
        public void SwitchPaymentStatus(int idCotisation)
        {
            _repository.Cotisation.UpdatePaymentStatus(idCotisation);
        }
    }
}
