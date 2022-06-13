﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IMembreRepository : IRepositoryBase<Membre>
    {
        void DisableMember(int idMembre);
    }
}
