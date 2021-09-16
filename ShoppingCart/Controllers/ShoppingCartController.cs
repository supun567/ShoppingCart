using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Repositories;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IBookRepository _bookRepo;
        private readonly EFShoppingCartRepository _cartRepo;

        public ShoppingCartController(IBookRepository bookRepo, EFShoppingCartRepository cartRepo)
        {
            _bookRepo = bookRepo;
            _cartRepo = cartRepo;

        }

        public IActionResult Index()
        {
            _cartRepo.ShoppingCartItems = _cartRepo.GetShoppingCartItems();

            return View(_cartRepo);
        }

        public RedirectToActionResult AddToShoppingCart(int Id)
        {
            var selectedBook = _bookRepo.GetBookById(Id);

            if (selectedBook != null)
            {
                _cartRepo.AddItem(selectedBook);
            }

            return RedirectToAction("Index");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int Id)
        {
            var selectedBook = _bookRepo.GetBookById(Id);

            if (selectedBook != null)
            {
                _cartRepo.RemoveItem(selectedBook);
            }

            return RedirectToAction("Index");
        }
    }
}
