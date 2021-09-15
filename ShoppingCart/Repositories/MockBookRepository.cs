using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.Repositories;


namespace ShoppingCart.Repositories
{
    public class MockBookRepository : IBookRepository
    {
        //private readonly IBookRepository _BookRepository;

        
        //private readonly ICategoryRepository _categoryRepository;
        //private readonly IAuthorRepository _authorRepository;
        //public MockBookRepository(ICategoryRepository categoryRepository, IAuthorRepository authorRepository)
        //{
        //    _categoryRepository = categoryRepository;
        //    _authorRepository = authorRepository;
        //}

        //public MockBookRepository(IBookRepository repo)
        //{
        //    _BookRepository = repo;
        //}

        public IEnumerable<Book> AllBooks => new List<Book> { 
            new Book
            {
                Id=101,
                Isbn="978-1-56619-909-4",
                Title="The Island",
                ReleaseYear=2019,
                Category= "",
                Price=150,
                ImageUrl="101.jpg",
                Author=""
            },
            new Book
            {
                Id=102,
                Isbn="978-1-56689-200-2",
                Title="Twilight",
                ReleaseYear=2020,
               Category= "",
                Price=150,
                ImageUrl="102.jpg",
                Author=""
            },
            new Book
            {
               Id=102,
                Isbn="978-1-56689-200-2",
                Title="Twilight",
                ReleaseYear=2020,
               Category= "",
                Price=150,
                ImageUrl="103.jpg",
                Author=""
            }
        };

        public IEnumerable<Book> BooksWithDiscount => new List<Book> {
            new Book
            {
                Id=101,
                Isbn="978-1-56619-909-4",
                Title="The Island",
                ReleaseYear=2019,
                Category= "",
                Price=150,
                ImageUrl="101.jpg",
                Author=""
            },
            
            new Book
            {
               Id=102,
                Isbn="978-1-56689-200-2",
                Title="Twilight",
                ReleaseYear=2020,
               Category= "",
                Price=150,
                ImageUrl="103.jpg",
                Author=""
            }
        };

        public Book GetBookByCategory(string categoryDescription)
        {
            return AllBooks.FirstOrDefault(c => c.Category == categoryDescription);
        }

        public Book GetBookById(int id)
        {
            return AllBooks.FirstOrDefault(c=>c.Id ==id);
        }

        public Book GetBookByIsbn(string isbn)
        {
            return AllBooks.FirstOrDefault(c => c.Isbn == isbn);
        }
    }
}
