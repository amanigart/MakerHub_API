using BusinessLogicLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataTransferObjects;
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
        
        public AuthenticationService(IRepositoryManager repository) => _repository = repository;

        // Retourne au controller un utilisateur (idUtilisateur + role)
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
