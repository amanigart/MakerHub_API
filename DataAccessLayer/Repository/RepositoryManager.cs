using DataAccessLayer.Interfaces;
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

        public RepositoryManager(IConfiguration config) : base(config)
        {
            _auhtenticationRepository = new Lazy<IAuthenticationRepository>(() => new AuthenticationRepository(config));
            _gestionnaireRepository = new Lazy<IGestionnaireRepository>(() => new GestionnaireRepository(config));
        }

        public IAuthenticationRepository Authentication => _auhtenticationRepository.Value; 
        public IGestionnaireRepository Gestionnaire => _gestionnaireRepository.Value;


    }
}
