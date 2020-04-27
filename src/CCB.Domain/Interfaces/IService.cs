using System.Collections.Generic;
using CCB.Domain.Model;
using FluentValidation;

namespace CCB.Domain.Interfaces
{
    public interface IService<T> where T : Base
    {
        T Insert<V>(T obj) where V : AbstractValidator<T>;
        T Update<V>(T obj) where V : AbstractValidator<T>;
        void Delete(int id);
        T Get(int id);
        IList<T> Get();
    }
}