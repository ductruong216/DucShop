using System;
using System.Linq;
using System.Linq.Expressions;

namespace ShopOnline.Data.Parttern
{
    public interface IRepository<T> where T : class
    {
        // Add new object of entity
        void Add(T entity);
        // Delete an object of entity
        void Delete(T entity);
        // Update an object of entity
        void Update(T entity);
        // Delete an object by ID
        void DeleteById(int id);
        // Delete with multi conditions
        void DeleteMulti(Expression<Func<T, bool>> where);

        // Get an entity by int ID
        T GetSingleById(int id);
        // Get an entity by conditions
        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        // IQueryable
        IQueryable<T> GetAll(string[] includes = null);
        // GetMulti Queryable
        IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);
        // Paging pages
        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null);
        int Count(Expression<Func<T, bool>> where);
        // CheckContains
        bool CheckContains(Expression<Func<T, bool>> predicate);

    }
}