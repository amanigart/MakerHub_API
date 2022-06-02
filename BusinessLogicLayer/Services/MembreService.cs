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
    public sealed class MembreService : IMembreService
    {
        public readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;

        public MembreService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public IEnumerable<MembreDto> GetMemberList()
        {
            var members = _repository.Membre.GetAll().Select(m => new { IdMembre = m.IdMembre, IdPersonne = m.IdPersonne});
            var persons = _repository.Personne.GetAll().Select(p => new { IdPersonne = p.IdPersonne, Nom = p.Nom, Prenom = p.Prenom});

            var membersDto = members.Join(persons,
                    member => member.IdPersonne,
                    person => person.IdPersonne,
                    (member, person) => 
                        new MembreDto
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

        public MembreDetailDto GetMemberDetail(int id)
        {
            Membre member = _repository.Membre.GetById(id);
            if (member is null)
                throw new MembreNotFoundException();
            
            var jiujitsuTopBelt = _repository.TopCeinture.GetTopCeinturesByMembre(member.IdMembre).Select(x => x.Couleur).FirstOrDefault();
            Personne person = _repository.Personne.GetById(member.IdPersonne);
            Adresse address = _repository.Adresse.GetById(person.IdAdresse);

            // TODO: ajouter contact + Referent

            return new MembreDetailDto()
            {
                IdMembre = member.IdMembre,
                Personne = person,
                Adresse = address,
                Photo = member.Photo,
                Sexe = member.Sexe,
                DateNaissance = member.DateNaissance.ToString("dd/MM/yyyy"),
                GroupeSanguin = member.GroupeSanguin,
                AutoriseImage = member.AutoriseImage,
                BasePresences = member.BasePresences,
                CeintureJiujitsu = jiujitsuTopBelt.ToString()
            };
        }

        public void DeleteMember(int id)
        {
            _repository.Membre.Delete(id);
        }

        // MembreCreation

        // MembreUpdate
    }
}
