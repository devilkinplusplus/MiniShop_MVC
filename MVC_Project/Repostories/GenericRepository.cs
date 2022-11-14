using MVC_Project.Models;

namespace MVC_Project.Repostories
{
    public class GenericRepository<T> where T:class
    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
            dbContext.SaveChanges();
        }

        public void Delete(T entiy)
        {
            dbContext.Set<T>().Remove(entiy);
            dbContext.SaveChanges();
        }

        public void Update(T entiy)
        {
            dbContext.Set<T>().Update(entiy);
            dbContext.SaveChanges();
        }

        public T Get(int id)
        {
            return dbContext.Set<T>().Find(id);
        }


       
    }
}
