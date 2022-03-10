using Quadrinhos.Domain.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quadrinhos.Domain.Interfaces
{
    public interface IServiceBase<TModel, TIdType> where TModel : class, IModel<TIdType>
    {
        Task<int> Update(TModel model);

        Task<int> Insert(TModel model);

        IQueryable<TModel> Get();

        IQueryable<TModel> Get(TIdType id);

        IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate);

        Task<int> Delete(TIdType id);
    }
}
