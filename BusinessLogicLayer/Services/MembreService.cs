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

        // Enregistre un nouveau membre
        public void CreateNewMember(MembreForCreationDto member)
        {

        }

        // Récupère la liste de tous les membres (actifs et inactifs), avec leurs infos de base (idMembre, nom, prénom)
        public IEnumerable<MembreForListDto> GetMemberList()
        {
            var members = _repository.Membre.GetAll().Select(m => new { IdMembre = m.IdMembre, IdPersonne = m.IdPersonne, EstActif = m.EstActif });
            var persons = _repository.Personne.GetAll().Select(p => new { IdPersonne = p.IdPersonne, Nom = p.Nom, Prenom = p.Prenom});

            var membersDto = members.Join(persons,
                    member => member.IdPersonne,
                    person => person.IdPersonne,
                    (member, person) => 
                        new MembreForListDto
                        {
                            IdMembre = member.IdMembre,
                            Nom = person.Nom,
                            Prenom = person.Prenom,
                            EstActif = member.EstActif
                        });

            return membersDto;
        }

        // Récupère les infos complètes d'un membre à partir de son id (idMembre)
        public MembreDto GetMemberDetail(int id)
        {
            Membre member = _repository.Membre.GetById(id);
            if (member is null)
                throw new MembreNotFoundException();

            bool isAdult = CheckIfMemberIsAdult(member.DateNaissance);
            Personne person = _repository.Personne.GetById(member.IdPersonne);
            Adresse? address = (isAdult) ? _repository.Adresse.GetById((int)person.IdAdresse) : null;

            IEnumerable<V_Ceinture> belts = _repository.V_Ceintures.GetAllByMember(member.IdMembre);

            ContactDto contactDto = GetContact(member.IdMembre);
            ReferentDto? referentDto = (isAdult) ? null : referentDto = GetReferent(member.IdMembre);

            IEnumerable<V_Cotisations>? cotisations = _repository.V_Cotisations.GetAllByMember((int)member.IdMembre);
            if (cotisations is null)
                throw new CotisationNotFoundException();

            return new MembreDto()
            {
                IdMembre = member.IdMembre,
                DateInscription = member.DateInscription,
                EstActif = member.EstActif,
                Personne = person,
                Adresse = address,
                Photo = member.Photo,
                Sexe = member.Sexe,
                DateNaissance = member.DateNaissance,
                GroupeSanguin = member.GroupeSanguin,
                AutoriseImage = member.AutoriseImage,
                BasePresencesRequises = member.BasePresencesRequises,
                BasePresencesTotal = member.BasePresencesTotal,
                Ceintures = belts,
                Contact = contactDto,
                Referent = referentDto,
                Cotisations = cotisations
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

            return new ContactDto()
            {
                Id = contact.Id,
                Personne = contactPerson,
                LienAvecMembre = contact.LienAvecMembre
            };
        }

        // Récupère le référent légal du membre si ce dernier est mineur, sinon retourne un référent null
        private ReferentDto GetReferent(int idMembre)
        {
            Referent referent = _repository.Referent.GetById(idMembre);
            Personne referentPerson = _repository.Personne.GetById(referent.IdReferent);
            Adresse referentAddress = _repository.Adresse.GetById((int)referentPerson.IdAdresse);

            return new ReferentDto()
            {
                Id = referent.Id,
                Personne = referentPerson,
                Adresse = referentAddress,
                LienAvecMembre = referent.LienAvecMembre
            };
        }

        // Vérifie si un membre est adulte ou mineur (renvoie true si adulte)
        private bool CheckIfMemberIsAdult(DateTime birthDate)
        {
            DateTime today = DateTime.Now;

            if (birthDate > today.AddYears(-18))
                return false;

            return true;
        }
    }
}
