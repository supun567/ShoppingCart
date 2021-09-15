using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Data;
using ShoppingCart.Models;

namespace ShoppingCart.Repositories
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private readonly EFContext _dbContext;

        public EFAuthorRepository(EFContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Author> AllAuthors
        {
            get { return _dbContext.Authors; }
        }

        public Author GetAuthorById(int id)
        {
            return _dbContext.Authors.FirstOrDefault(a=>a.Id==id);
        }
    }
}
