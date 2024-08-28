using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    // Generic Repository : tasarım desenidir. Temel CRUD işlemlerini tanımlar
    // Generic Constraint -> T türünü sınırlar
    // class : referans tür
    // IEntity: IEntity olan ya da IEntity türünü implemente eden
    // new : newlenebilir (Yani interfaceler(IEntity) kullanılamaz
    public interface IEntityRepository<T> where T : class, IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
