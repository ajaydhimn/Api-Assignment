using ApiAssignment.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ApiAssignment.ServiceInterface
{
    public interface IBaseDbService<T> where T : BaseEntity
    {
        List<T> GetAll();

        T Get(string id);

        T Get(Expression<Func<T, bool>> expressions);

        List<T> GetAll(Expression<Func<T, bool>> expressions);

        T Create(T book);

        void Update(string id, T bookIn);

        void Remove(Car bookIn);

        void Remove(string id);
    }
}