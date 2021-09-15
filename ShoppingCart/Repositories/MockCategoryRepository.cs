using System;
using System.Collections.Generic;
using System.Linq;
using ShoppingCart.Models;


namespace ShoppingCart.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        //private readonly ICategoryRepository _categoryRepository;

        //public MockCategoryRepository(ICategoryRepository repo)
        //{
        //    _categoryRepository = repo;
        //}

        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category{CategoryId=1,Description="Novel" },
            new Category{CategoryId=2,Description="Romance" },
            new Category{CategoryId=2,Description="Mystery" }
        };

        public Category GetCategoryByDescription(string description)
        {
            return AllCategories.FirstOrDefault(c => c.Description == description);
        }

        public Category GetCategoryById(int id)
        {
            return AllCategories.FirstOrDefault(c => c.CategoryId == id);
        }
    }
}
