using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALTripster.IRepos
{
    public interface IRepo<T> where T : class
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);

        void Add(T entity);
        void Update(T entity);
        void Delete(int id);

        void Save();
    }

}
