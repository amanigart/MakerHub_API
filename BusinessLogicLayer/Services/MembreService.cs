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

        // Récupère la liste de tous les membres (actifs et inactifs)
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

        // Récupère les infos complètes d'un membre
        public MembreDetailDto GetMemberDetail(int id)
        {
            Membre member = _repository.Membre.GetById(id);
            if (member is null)
                throw new MembreNotFoundException();

            Personne person = _repository.Personne.GetById(member.IdPersonne);
            Adresse address = _repository.Adresse.GetById(person.IdAdresse);
            IEnumerable<V_Ceinture> belts = _repository.V_Ceintures.GetAllByMember(member.IdMembre);

            ContactDto contactDto = GetContact(member.IdMembre);
            ReferentDto? referentDto = GetReferent(member.IdMembre, member.DateNaissance);

            return new MembreDetailDto()
            {
                IdMembre = member.IdMembre,
                Personne = person,
                Adresse = address,
                Photo = member.Photo,
                Sexe = member.Sexe,
                DateNaissance = member.DateNaissance,
                GroupeSanguin = member.GroupeSanguin,
                AutoriseImage = member.AutoriseImage,
                BasePresences = member.BasePresences,
                Ceintures = belts,
                Contact = contactDto,
                Referent = referentDto
            };
        }

        // Supprime un membre sur la base de son id
        public void DeleteMember(int idMembre) => _repository.Membre.Delete(idMembre);

        // MembreCreation
        // MembreUpdate

        // Récupère la personne de contact d'un membre, à partir de l'id de celui-ci
        private ContactDto GetContact(int idMembre)
        {
            Contact contact = _repository.Contact.GetById(idMembre);
            Personne contactPerson = _repository.Personne.GetById(contact.IdContact);
            Adresse contactAdress = _repository.Adresse.GetById(contactPerson.IdAdresse);

            return new ContactDto()
            {
                Id = contact.Id,
                Personne = contactPerson,
                Adresse = contactAdress,
                LienAvecMembre = contact.LienAvecMembre
            };
        }

        // Récupère le référent légal du membre si ce dernier est mineur, sinon retourne un référent null
        private ReferentDto? GetReferent(int idMembre, DateTime dateNaiss)
        {
            DateTime today = DateTime.Now;

            if (dateNaiss <= today.AddYears(-18))
                return null;

            Referent referent = _repository.Referent.GetById(idMembre);
            Personne referentPerson = _repository.Personne.GetById(referent.IdReferent);
            Adresse referentAddress = _repository.Adresse.GetById(referentPerson.IdAdresse);

            return new ReferentDto()
            {
                Id = referent.Id,
                Personne = referentPerson,
                Adresse = referentAddress,
                LienAvecMembre = referent.LienAvecMembre
            };
        }
    }
}
