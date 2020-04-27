using CCB.Domain.Model;
using System.Collections.Generic;

namespace CCB.Domain.Interfaces
{
    public interface IRepository<T> where T : Base
    {
        void Insert(T obj);
        void Update(T obj);
        void Delete(int id);
        T Select(int id);
        IList<T> Select();
    }
}