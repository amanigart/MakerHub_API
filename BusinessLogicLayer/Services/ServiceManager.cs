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

        public ServiceManager(IRepositoryManager repository, ILoggerManager logger)
        {
            _authenticationService = new Lazy<IAuthenticationService>(() => new AuthenticationService(repository, logger));
            _membreService = new Lazy<IMembreService>(() => new MembreService(repository, logger));
        }

        public IAuthenticationService Authentication { get => _authenticationService.Value; }
        public IMembreService Membre { get => _membreService.Value; }
    }
}
