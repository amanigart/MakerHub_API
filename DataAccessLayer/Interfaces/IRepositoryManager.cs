﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryManager
    {
        IAuthenticationRepository Authentication { get; }
        IGestionnaireRepository Gestionnaire { get; }
        IRepositoryBase<Adresse> Adresse { get; }
        IRepositoryBase<Personne> Personne { get; }
        IRepositoryBase<Membre> Membre { get; }
        IRepositoryBase<Contact> Contact { get; }
        IRepositoryBase<Referent> Referent { get; }
        IDisciplineRepository Discipline { get; }
        IRepositoryBase<Ceinture> Ceinture { get; }
        ICeintureMembreRepository CeintureMembre { get; }
        IHoraireRepository Horaire { get; }
        IEntrainementRepository Entrainement { get; }
        IPresenceRepository Presence { get; }
    }
}