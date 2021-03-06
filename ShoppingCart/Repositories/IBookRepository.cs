using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get; }
        
        IEnumerable<Book> OnSale { get; }

        Book GetBookById(int id);

        Book GetBookByIsbn(string isbn);

        Book GetBookByCategory(string categoryDescription);

        List<Book> GetBooksOfAuthor(string fullName);
    }
}
