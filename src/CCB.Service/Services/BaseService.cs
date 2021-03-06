﻿using CCB.Domain.Interfaces;
using CCB.Domain.Model;
using CCB.Infra.Data.Repository;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CCB.Service.Services
{
    public class BaseService<T> : IService<T> where T : Base
    {
        private BaseRepository<T> repository = new BaseRepository<T>();

        public T Insert<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Insert(obj);
            return obj;
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            repository.Update(obj);
            return obj;
        }

        public void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            repository.Delete(id);
        }

        public IList<T> Get() => repository.Select();

        public T Get(int id)
        {
            if (id == 0)
                throw new ArgumentException("O id não pode ser zero.");

            return repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
