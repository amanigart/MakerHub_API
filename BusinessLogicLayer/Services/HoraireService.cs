using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
using Entities.Models;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class HoraireService : IHoraireService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public HoraireService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public IEnumerable<Horaire> getAllHoraires()
        {
            // TODO: mapping en horaireDto
            return _repository.Horaire.GetAll();
        }

        public Horaire getHoraireById(int id)
        {
            return _repository.Horaire.GetById(id);
        }

        public void UpdateHoraire(HoraireDto scheduleDto)
        {
            var schedule = _mapper.Map<Horaire>(scheduleDto);
            _repository.Horaire.Update(schedule);
        }
    }
}
