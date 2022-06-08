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

        public HoraireService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
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
    }
}
