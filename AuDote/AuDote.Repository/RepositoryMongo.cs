using AuDote.Database;
using AuDote.Database.Models;
using AuDote.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AuDote.Repository
{
    public class MongoDBRepository<T>(MongoDbContext mongoDBContext) : IRepository<T> where T : class
    {
        private readonly MongoDbContext _mongoDBContext = mongoDBContext;
        
        public void Add(T entity)
        {
            _mongoDBContext.Add(entity);

            _mongoDBContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            return _mongoDBContext.Set<T>().ToList();
        }

        public T GetById(string? id)
        {
            return _mongoDBContext.Set<T>().Find(id);
        }

        public T GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
