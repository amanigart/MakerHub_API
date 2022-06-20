using AutoMapper;
using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IAuthenticationService> _authenticationService;
        private readonly Lazy<IMembreService> _membreService;
        private readonly Lazy<IDisciplineService> _disciplineService;
        private readonly Lazy<ICeintureService> _ceintureService;
        private readonly Lazy<IHoraireService> _horaireService;
        private readonly Lazy<ITarifService> _tarifService;
        private readonly Lazy<ICotisationService> _cotisationService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repository));
            _membreService = new Lazy<IMembreService>(() => new MembreService(repository, logger, mapper));
            _disciplineService = new Lazy<IDisciplineService>(() => new DisciplineService(repository, logger));
            _ceintureService = new Lazy<ICeintureService>(() => new CeintureService(repository, logger));
            _horaireService = new Lazy<IHoraireService>(() => new HoraireService(repository, logger, mapper));
            _tarifService = new Lazy<ITarifService>(() => new TarifService(repository, mapper));
            _cotisationService = new Lazy<ICotisationService>(() => new CotisationService(repository, logger, mapper));
        }

        public IAuthenticationService Authentication => _authenticationService.Value;
        public IMembreService Membre => _membreService.Value; 
        public IDisciplineService Discipline => _disciplineService.Value;
        public ICeintureService Ceinture => _ceintureService.Value;
        public IHoraireService Horaire => _horaireService.Value;
        public ITarifService Tarif => _tarifService.Value;
        public ICotisationService Cotisation => _cotisationService.Value;
    }
}
