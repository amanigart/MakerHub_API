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
        private readonly Lazy<ICeintureService> _ceintureService;
        private readonly Lazy<IHoraireService> _horaireService;

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repository, logger));
            _membreService = new Lazy<IMembreService>(() => new MembreService(repository, logger));
            _ceintureService = new Lazy<ICeintureService>(() => new CeintureService(repository, logger));
            _horaireService = new Lazy<IHoraireService>(() => new HoraireService(repository, logger));
        }

        public IAuthenticationService Authentication => _authenticationService.Value;
        public IMembreService Membre => _membreService.Value; 
        public ICeintureService Ceinture => _ceintureService.Value;
        public IHoraireService Horaire => _horaireService.Value;
    }
}
