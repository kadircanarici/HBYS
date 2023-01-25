using HBYS.Data;
using HBYS.Models;
using HBYS.Repository.Shared.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HBYS.Repository.Shared.Concrete
{
    public class Repository<T>:IRepository<T> where T : ModelBase
    {

        private readonly ApplicationDbContext _db;
        internal DbSet<T> _dbSet;

        public Repository(ApplicationDbContext db)
        {
            _db = db;
            _dbSet = _db.Set<T>();
        }

        public bool Add(T entity)
        {
            _dbSet.Add(entity);
            return true;

        }

        public bool AddRange(IEnumerable<T> entities)
        {
            _dbSet.AddRange(entities);
            return true;
        }

        public IEnumerable<T> GetAll()
        {

            return _dbSet.Where(t => t.IsDeleted == false && t.IsActive == true).ToList();



        }
        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {

            return _dbSet.Where(predicate).ToList();
        }
        public T GetFirstOrDefault(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> result = _dbSet.Where(predicate);
            return result.FirstOrDefault();
        }

        public bool Remove(T entity)
        {
            entity.IsDeleted = true;
            entity.DateModified = DateTime.Now;
            _dbSet.Update(entity);
            return true;
        }

        public bool RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            return entity;
        }
    }
}
