using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DIO.CharCreate
{
    public interface IRepository <T>
    {
        int NextId();
        List<T> ListOf();
        void Insert(T entity);
        void Remove(int id);
        void Update(int id, T entity);
        T GetById(int id);
    }
}