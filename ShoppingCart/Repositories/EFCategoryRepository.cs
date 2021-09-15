using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly EFContext _dbContext;

        public EFCategoryRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> AllCategories
        {
            get { return _dbContext.Categories; }
        }

        public Category GetCategoryByDescription(string description)
        {
            return _dbContext.Categories.FirstOrDefault(c=>c.Description==description);
        }

        public Category GetCategoryById(int id)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
