using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WolfClan.SoliHub.API.Auth
{
    public interface IUserRepository<TEntity>
    {
            IList<TEntity> List();
            TEntity Find(int id);
            TEntity FindWithEmail(string mail);
            void Add(TEntity entity);
            void Edit(int id, TEntity entity);
            void Delete(int id);

        
    }
}
