using System;
using System.Collections.Generic;
using System.Text;

namespace ppedv.Pillenpresse.Model.Contracts
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>();
        T GetById<T>(int id);
        void Add<T>(T entity);
        void Delete<T>(T entity);
        void Save();
    }
}
