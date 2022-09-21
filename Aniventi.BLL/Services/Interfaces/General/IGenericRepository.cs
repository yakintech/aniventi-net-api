using Aniventi.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Aniventi.BLL.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {

        //Senkron ve asenkton repo metotlarım

        IQueryable<T> GetAllWithQueryable();

        List<T> GetAll();

        T GetById(Guid id);

        void Add(T entity);

        void Remove(Guid id);

        void HardDelete(T entity);

        List<T> GetListByQueries(Expression<Func<T, bool>> filter);

        IQueryable<T> GetQueryableListByQueries(Expression<Func<T, bool>> filter);

        T GetByQuery(Expression<Func<T, bool>> filter);

        void Update(T entity);


    }
}
