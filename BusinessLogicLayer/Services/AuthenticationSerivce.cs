using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
using LoggerService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services
{
    public sealed class AuthenticationService : IAuthenticationService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        
        public AuthenticationService(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public AppUtilisateurDto Login(string login, string password)
        {
            var user = _repository.Authentication.Login(login, password);
            bool isGestionnaire = _repository.Gestionnaire.CheckIfIsGestionnaire(user.IdUtilisateur);

            AppUtilisateurDto userDto;

            if (isGestionnaire)
                userDto = new() { Id = user.IdUtilisateur, Role = "gestionnaire" };
            else 
                userDto = new() { Id = user.IdUtilisateur, Role = "membre" };

            return userDto;
        }

    }
}
