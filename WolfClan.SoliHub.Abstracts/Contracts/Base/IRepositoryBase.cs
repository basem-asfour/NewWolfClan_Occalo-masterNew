using WolfClan.SoliHub.Messages.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace WolfClan.SoliHub.Abstracts.Contracts.Base
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        IDbConnection GetOpenConnection();
        Task<IResponseMessage<TEntity>> Add(TEntity obj);
        Task<IResponseMessage<TEntity>> GetById(int? id);
        Task<IResponseMessage<TEntity>> GetAll(QueryParameters request);
        Task<IResponseMessage<TEntity>> Update(TEntity obj);
        Task<IResponseMessage<TEntity>> Remove(TEntity obj);
        Task<IResponseMessage<TEntity>> Remove(int? id);
    }
}
