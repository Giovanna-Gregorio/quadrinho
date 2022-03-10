using Quadrinhos.Domain.Interfaces;
using Quadrinhos.Domain.Models;
using Quadrinhos.Repository.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Quadrinhos.Services
{
    public class ServiceBase<TModel, TIdType> : IServiceBase<TModel, TIdType>
        where TModel : class, IModel<TIdType>
    {
        public ApplicationDbContext _db;

        public ServiceBase(ApplicationDbContext db)
        {
            _db = db;
        }

        public virtual IQueryable<TModel> Get(TIdType id)
        {
            return _db.Set<TModel>()
                .Where(p => p.Id.Equals(id))
                .AsQueryable();
        }

        public virtual IQueryable<TModel> Get()
        {
            return _db.Set<TModel>().AsQueryable();
        }

        public virtual IQueryable<TModel> Get(Expression<Func<TModel, bool>> predicate)
        {
            return _db.Set<TModel>().Where(predicate).AsQueryable();
        }

        public virtual async Task<int> Insert(TModel model)
        {
            _db.Add<TModel>(model);

            return await _db.SaveChangesAsync();
        }

        public virtual async Task<int> Update(TModel model)
        {
            _db.Update<TModel>(model);

            return await _db.SaveChangesAsync();
        }

        public virtual async Task<int> Delete(TIdType id)
        {
            TModel model = Get(id).FirstOrDefault();

            if (model != null)
            {
                _db.Entry<TModel>(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

                return await _db.SaveChangesAsync();
            }

            return -1;
        }
    }
}
