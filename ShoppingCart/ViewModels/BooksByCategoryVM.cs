using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.ViewModels
{
    public class BooksByCategoryVM
    {
        public IEnumerable<Book> Books { get; set; }

        public string Category { get; set; }
    }
}
