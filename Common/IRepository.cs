using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public interface IRepository<TEntity>
    {
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        int Insert(TEntity entity);
        void Delete(int id);
        void Update(int id, TEntity entity);
    }
}
