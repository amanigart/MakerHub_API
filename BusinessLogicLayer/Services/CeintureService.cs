using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
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

        public CeintureService(IRepositoryManager repository)
        {
            _repository = repository;
        }

        public IEnumerable<CeintureDto> GetAllCeinutres()
        {
            var belts = _repository.Ceinture.GetAll();
            var disciplines = _repository.Discipline.GetAll();

            //TODO: Join

            throw new NotImplementedException();
        }
    }
}
