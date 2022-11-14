using Microsoft.EntityFrameworkCore;
using MVC_Project.Models;

namespace MVC_Project.Repostories
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public List<Category> GetAllActive()
        {
            using var dbContext = new AppDbContext();
            return dbContext.Categories.Where(x=>x.IsDeleted==false).ToList();
        }
    }
}
