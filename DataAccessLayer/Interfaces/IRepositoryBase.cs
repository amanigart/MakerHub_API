using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id); 
    }
}
