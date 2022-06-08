using BusinessLogicLayer.Interfaces;
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
    public sealed class CeintureService : ICeintureService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public CeintureService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<CeintureDto> GetAllCeinutres()
        {
            var belts = _repository.Ceinture.GetAll();
            var disciplines = _repository.Discipline.GetAll();

            var beltsDto = belts.Join(disciplines,
                belt => belt.IdDiscipline,
                discipline => discipline.IdDiscipline,
                (belt, discipline) => 
                    new CeintureDto
                    {
                        IdCeinture = belt.IdCeinture,
                        Couleur = belt.Couleur,
                        NbPresencesRequis = belt.nbPresencesRequis,
                        Illustration = belt.Illustration,
                        Discipline = discipline
                    });

            return beltsDto;
        }

        public CeintureDto GetCeintureById(int idCeinture)
        {
            Ceinture belt = _repository.Ceinture.GetById(idCeinture);
            if (belt is null)
                throw new CeintureNotFoundException();

            Discipline discipline = _repository.Discipline.GetById(belt.IdDiscipline);
            if (discipline is null)
                throw new DisciplineNotFoundException();

            CeintureDto beltDto = new CeintureDto
            {
                IdCeinture = belt.IdCeinture,
                Couleur = belt.Couleur,
                NbPresencesRequis = belt.nbPresencesRequis,
                Illustration = belt.Illustration,
                Discipline = discipline
            };

            return beltDto;
        }
    }
}
