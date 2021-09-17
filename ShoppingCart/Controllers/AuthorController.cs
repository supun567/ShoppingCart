using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCart.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo)
        {
            _authorRepo = authorRepo;
        }

        public ViewResult AllAuthors()
        {
            return View(_authorRepo.AllAuthors);
        }
    }
}
