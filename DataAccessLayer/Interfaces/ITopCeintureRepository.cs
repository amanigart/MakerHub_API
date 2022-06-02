﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITopCeintureRepository
    {
        IEnumerable<TopCeinture> GetTopCeintures();
        IEnumerable<TopCeinture> GetTopCeinturesByMembre(int idMembre);
    }
}
