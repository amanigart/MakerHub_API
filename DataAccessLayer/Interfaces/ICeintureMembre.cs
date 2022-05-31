using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ICeintureMembreRepository
    {
        int Create(CeintureMembre ceinture);
        IEnumerable<CeintureMembre> GetAllByIdCeinture(int id);
        IEnumerable<CeintureMembre> GetAllByIdMembre(int id);
        CeintureMembre GetOne(int idCeinture, int idMembre);
    }
}
