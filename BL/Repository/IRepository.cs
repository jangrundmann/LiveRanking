using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataAccess
{
    public interface IRepository<T>
    {
        IQueryable<T> Get();
        T Get(int id);
        T Add(T obj);
        T Update(T obj);
        void Delete(T obj);
    }
}
