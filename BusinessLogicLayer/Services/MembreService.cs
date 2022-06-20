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
    public sealed class MembreService : IMembreService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;

        public MembreService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }


        // Inscription d'un nouveau membre
        public void CreateNewMember(MembreForCreationDto newMember)
        {
            bool isAdult = newMember.MembreInfos.DateNaissance.CheckIfAdult();

            Adresse address = _mapper.Map<Adresse>(newMember.Adresse);
            int? addressId = (isAdult) ? _repository.Adresse.Create(address) : null;

            Personne person = _mapper.Map<Personne>(newMember.Personne);
            person.IdAdresse = addressId;
            int personId = _repository.Personne.Create(person);

            Membre member = _mapper.Map<Membre>(newMember.MembreInfos);
            member.IdPersonne = personId;
            int memberId = _repository.Membre.Create(member);

            var belts = _mapper.Map<IEnumerable<CeintureMembre>>(newMember.Ceintures);
            foreach (var belt in belts)
            {
                belt.IdMembre = memberId;
                _repository.CeintureMembre.Create(belt);
            }

            CreateContactForMember(newMember.Contact, memberId);
            if (!isAdult) CreateReferentForMember(newMember.Referent, memberId);

            Cotisation membership = _mapper.Map<Cotisation>(newMember.Cotisation);
            membership.DateFin = membership.DateDebut.GetCotisationEndDate(newMember.Cotisation.Duree);
            membership.IdMembre = memberId;

            _repository.Cotisation.Create(membership);  
        }

        // Ajoute une nouvelle ceinture au membre
        public void CreateNewBeltForMember(CeintureMembreForCreationDto belt)
        {
            var memberBelt = _mapper.Map<CeintureMembre>(belt);
            _repository.CeintureMembre.Create(memberBelt);
        }

        // Récupère la liste de tous les membres (actifs et inactifs), avec leurs infos de base (idMembre, nom, prénom)
        public IEnumerable<MembreForListDto> GetMemberList()
        {
            var members = _repository.Membre.GetAll().Select(m => new { IdMembre = m.IdMembre, IdPersonne = m.IdPersonne, EstActif = m.EstActif, DateNaissance = m.DateNaissance, DateInscription = m.DateInscription });
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
                            EstActif = member.EstActif,
                            Age = member.DateNaissance.GetAge(),
                            DateInscription = member.DateInscription
                        });

            return membersDto;
        }


        // Récupère les infos complètes d'un membre à partir de son id (idMembre)
        public MembreDto GetMemberDetail(int id)
        {
            Membre member = _repository.Membre.GetById(id);
            if (member is null)
                throw new MembreNotFoundException();

            bool isAdult = member.DateNaissance.CheckIfAdult();
            Personne person = _repository.Personne.GetById(member.IdPersonne);
            Adresse? address = (isAdult) ? _repository.Adresse.GetById((int)person.IdAdresse) : null;

            var belts = _repository.V_Ceintures.GetAllByMember(member.IdMembre);

            ContactDto contactDto = GetContact(member.IdMembre);
            ReferentDto? referentDto = (isAdult) ? null : referentDto = GetReferent(member.IdMembre);

            var cotisations = _repository.V_Cotisations.GetAllByMember((int)member.IdMembre);
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


        // Réactive un membre inactif
        public void ActivateMember(int idMembre) => _repository.Membre.ActivateMember(idMembre);


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


        // Enregistre un nouveau contact lors de la création d'un membre
        private void CreateContactForMember(ContactForCreationDto newContact, int memberId)
        {
            Personne contactPerson = _mapper.Map<Personne>(newContact.Personne);
            int contactId = _repository.Personne.Create(contactPerson);

            Contact contact = new()
            {
                IdMembre = memberId,
                IdContact = contactId,
                LienAvecMembre = newContact.LienAvecMembre
            };
            _repository.Contact.Create(contact);
        }


        // Enregistre un nouveau référent lors de la création d'un membre
        private void CreateReferentForMember(ReferentForCreationDto newReferent, int memberId)
        {
            Adresse referentAddress = _mapper.Map<Adresse>(newReferent.Adresse);
            int addressId = _repository.Adresse.Create(referentAddress);

            Personne referentPerson = _mapper.Map<Personne>(newReferent.Personne);
            referentPerson.IdAdresse = addressId;
            int referentId = _repository.Personne.Create(referentPerson);

            Referent referent = new()
            {
                IdMembre = memberId,
                IdReferent = referentId,
                LienAvecMembre = newReferent.LienAvecMembre
            };
            _repository.Referent.Create(referent);
        }
    }
}
