using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;


namespace ShoppingCart.Repositories
{
    public class MockAuthorRepository : IAuthorRepository
    {
        //private readonly IAuthorRepository _authorRepository;

        //public MockAuthorRepository(IAuthorRepository repo)
        //{
        //    _authorRepository = repo;
        //}
        public IEnumerable<Author> AllAuthors => new List<Author>
        {
            new Author
            {
                Id=101,
                FirstName="Neeman",
                LastName="Gomez"
            },
             new Author
            {
                Id=102,
                FirstName="Jerrad",
                LastName="Powel"
            },
            new Author
            {
                Id=103,
                FirstName="Diana",
                LastName="Rowling"
            },
             new Author
            {
                Id=104,
                FirstName="Pierces",
                LastName="Matilda"
            }

        };

        public Author GetAuthorById(int id)
        {
            return AllAuthors.FirstOrDefault(c => c.Id == id);
        }
    }
}
