using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> AllCategories { get; }

        Category GetCategoryByDescription(string description);

        Category GetCategoryById(int id);
    }
}
