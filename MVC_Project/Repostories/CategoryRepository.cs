using MVC_Project.Models;

namespace MVC_Project.Repostories
{
    public class CategoryRepository
    {
        AppDbContext dbContext = new AppDbContext();

        public void Add(Category category)
        {
            dbContext.Categories.Add(category);
            dbContext.SaveChanges();
        }

        public void Delete(Category category)
        {
            dbContext.Categories.Remove(category);
            dbContext.SaveChanges();
        }

        public void Update(Category category)
        {
            dbContext.Categories.Update(category);
            dbContext.SaveChanges();
        }

        public Category Get(int id)
        {
            return dbContext.Categories.Find(id);
        }

        public List<Category> GetAll()
        {
            return dbContext.Categories.ToList();
        }

        public List<Category> GetAllActive()
        {
            return dbContext.Categories.Where(x=>x.IsDeleted==false).ToList();
        }
    }
}
