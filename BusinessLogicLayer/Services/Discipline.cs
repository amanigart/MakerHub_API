using BusinessLogicLayer.Interfaces;
//using DataAccessLayer.Interfaces;
using LoggerService;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Interfaces;

namespace BusinessLogicLayer.Services
{
    public sealed class DisciplineService : IDisciplineService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public DisciplineService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<Discipline> GetAllDisciplines()
        {
            return _repository.Discipline.GetAll();
        }
    }
}
