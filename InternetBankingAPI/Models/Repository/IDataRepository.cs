using System.Collections.Generic;
using System.Threading.Tasks;

namespace InternetBankingAPI.Models.Repository
{
    interface IDataRepository<TKey, TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAll();

        Task<TEntity> Get(TKey key);

        Task<TKey> Update(TKey key, TEntity entity);
    }
}
