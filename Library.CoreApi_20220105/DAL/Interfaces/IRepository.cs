using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.CoreApi_20220105.DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity:class
    {

        Task<IEnumerable<TEntity>> Get();

        Task<TEntity> Get(int id);

        Task<object> Post(TEntity entity);

        Task<object> Put(int id, TEntity entity);

        Task<object> Delete(int id);
    }
}
