using DataAccessLayer.Interfaces;
using Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repository
{
    public sealed class RepositoryManager : RepositoryBase, IRepositoryManager
    {
        private readonly Lazy<IAuthenticationRepository> _auhtenticationRepository;
        private readonly Lazy<IGestionnaireRepository> _gestionnaireRepository;
        private readonly Lazy<IRepositoryBase<Adresse>> _adresseRepository;
        private readonly Lazy<IRepositoryBase<Personne>> _personneRepository;
        private readonly Lazy<IMembreRepository> _membreRepository;
        private readonly Lazy<IRepositoryBase<Contact>> _contactRepository;
        private readonly Lazy<IRepositoryBase<Referent>> _referentRepository;
        private readonly Lazy<IDisciplineRepository> _disciplineRepository;
        private readonly Lazy<IRepositoryBase<Ceinture>> _ceintureRepository;
        private readonly Lazy<ICeintureMembreRepository> _ceintureMembreRepository;
        private readonly Lazy<IV_CeintureRepository> _vCeinturesRepository;
        private readonly Lazy<IHoraireRepository> _horaireRepository;
        private readonly Lazy<IEntrainementRepository> _entrainementRepository;
        private readonly Lazy<IPresenceRepository> _presenceRepository;
        private readonly Lazy<IRepositoryBase<Tarif>> _tarifRepository;
        private readonly Lazy<IRepositoryBase<Cotisation>> _cotisationRepository;
        private readonly Lazy<IV_CotisationsRepository> _vCotisationsRepository;

        public RepositoryManager(IConfiguration config) : base(config)
        {
            _auhtenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(config));
            _gestionnaireRepository = new Lazy<IGestionnaireRepository>(() => new GestionnaireRepository(config));
            _adresseRepository = new Lazy<IRepositoryBase<Adresse>>(() => new AdresseRepository(config));
            _personneRepository = new Lazy<IRepositoryBase<Personne>>(() => new PersonneRepository(config));
            _membreRepository = new Lazy<IMembreRepository>(() => new MembreRepository(config));
            _contactRepository = new Lazy<IRepositoryBase<Contact>>(() => new ContactRepository(config));
            _referentRepository = new Lazy<IRepositoryBase<Referent>>(() => new ReferentRepository(config));
            _disciplineRepository = new Lazy<IDisciplineRepository>(() => new DisciplineRepository(config));
            _ceintureRepository = new Lazy<IRepositoryBase<Ceinture>>(() => new CeintureRepository(config));
            _ceintureMembreRepository = new Lazy<ICeintureMembreRepository>(() => new CeintureMembreRepository(config));
            _vCeinturesRepository = new Lazy<IV_CeintureRepository>(() => new V_CeintureRepository(config));
            _horaireRepository = new Lazy<IHoraireRepository>(() => new HoraireRepository(config));
            _entrainementRepository = new Lazy<IEntrainementRepository>(() => new EntrainementRepository(config));
            _presenceRepository = new Lazy<IPresenceRepository>(() => new PresenceRepository(config));
            _tarifRepository = new Lazy<IRepositoryBase<Tarif>>(() => new TarifRepository(config));
            _cotisationRepository = new Lazy<IRepositoryBase<Cotisation>>(() => new CotisationRepository(config));
            _vCotisationsRepository = new Lazy<IV_CotisationsRepository>(() => new V_CotisationsRepository(config));
        }

        public IAuthenticationRepository Authentication => _auhtenticationRepository.Value; 
        public IGestionnaireRepository Gestionnaire => _gestionnaireRepository.Value;
        public IRepositoryBase<Adresse> Adresse => _adresseRepository.Value;
        public IRepositoryBase<Personne> Personne => _personneRepository.Value;
        public IMembreRepository Membre => _membreRepository.Value;
        public IRepositoryBase<Contact> Contact => _contactRepository.Value;
        public IRepositoryBase<Referent> Referent => _referentRepository.Value;
        public IDisciplineRepository Discipline => _disciplineRepository.Value;
        public IRepositoryBase<Ceinture> Ceinture => _ceintureRepository.Value;
        public ICeintureMembreRepository CeintureMembre => _ceintureMembreRepository.Value;
        public IV_CeintureRepository V_Ceintures => _vCeinturesRepository.Value;
        public IHoraireRepository Horaire => _horaireRepository.Value;
        public IEntrainementRepository Entrainement => _entrainementRepository.Value;
        public IPresenceRepository Presence => _presenceRepository.Value;
        public IRepositoryBase<Tarif> Tarif => _tarifRepository.Value;
        public IRepositoryBase<Cotisation> Cotisation => _cotisationRepository.Value;
        public IV_CotisationsRepository V_Cotisations => _vCotisationsRepository.Value;
    }
}
