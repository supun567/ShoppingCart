using ShoppingCart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Data;

namespace ShoppingCart.Repositories
{
    public class EFBookRepository : IBookRepository
    {

        private readonly EFContext _dbContext;

        public EFBookRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Book> AllBooks
        { 
            get { return _dbContext.Books; }
        }

        public IEnumerable<Book> OnSale
        {
            get { return _dbContext.Books.Where(p => p.Price < 100); }
        }

        public Book GetBookByCategory(string categoryDescription)
        {
            return _dbContext.Books.FirstOrDefault(b => b.Category== categoryDescription);
        }

        public Book GetBookById(int id)
        {
            return _dbContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book GetBookByIsbn(string isbn)
        {
            return _dbContext.Books.FirstOrDefault(b => b.Isbn == isbn);
        }


        public List<Book> GetBooksOfAuthor(string name)
        {
            return _dbContext.Books.Where(b => b.Author == name).ToList();
        }
    }
}
