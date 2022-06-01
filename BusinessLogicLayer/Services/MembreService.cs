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
    public sealed class MembreService : IMembreService
    {
        public readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public MembreService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<MembreBasicDto> GetMemberList()
        {
            var members = _repository.Membre.GetAll().Select(m => new { IdMembre = m.IdMembre, IdPersonne = m.IdPersonne});
            var persons = _repository.Personne.GetAll().Select(p => new { IdPersonne = p.IdPersonne, Nom = p.Nom, Prenom = p.Prenom});

            var membersDto = members.Join(persons,
                    member => member.IdPersonne,
                    person => person.IdPersonne,
                    (member, person) => 
                        new MembreBasicDto
                        {
                            IdMembre = member.IdMembre,
                            Nom = person.Nom,
                            Prenom = person.Prenom
                        });

            return membersDto;
        }

        //public async Task<IEnumerable<MembreBasicDto>> GetMemberListAsync()
        //{
        //    var members = await _repository.Membre.GetAllAsync();//.Select(m => new { IdMembre = m.IdMembre, IdPersonne = m.IdPersonne });
        //    var persons = _repository.Personne.GetAll().Select(p => new { IdPersonne = p.IdPersonne, Nom = p.Nom, Prenom = p.Prenom });

        //    var membersDto = members.Join(persons,
        //            member => member.IdPersonne,
        //            person => person.IdPersonne,
        //            (member, person) =>
        //                new MembreBasicDto
        //                {
        //                    IdMembre = member.IdMembre,
        //                    Nom = person.Nom,
        //                    Prenom = person.Prenom
        //                });

        //    return membersDto;
        //}


    }
}
