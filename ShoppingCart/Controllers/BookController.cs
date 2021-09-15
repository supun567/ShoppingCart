﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;
using ShoppingCart.Repositories;

namespace ShoppingCartDemo.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;
        
        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
           
        }

        public ViewResult Catalog()
        {
            return View(_bookRepo.AllBooks);
        }

        public ViewResult OnSale()
        {
            return View(_bookRepo.BooksWithDiscount);
        }

        #region CodeToBeDisposed
        //public ViewResult ByCategory()
        //{
        //    List<Book> Books = _bookRepo.AllBooks.ToList();

        //    BookListVM bookListVM = new()
        //    {
        //        Books = _bookRepo.AllBooks.Where(c=>c.Category == _categoryRepo.GetCategoryById(1).Description),
        //        SelectedCategoryDescription= _categoryRepo.GetCategoryById(2).Description
        //    };

        //    return View(bookListVM);
        //}

        //public void BookPurchased(int id)
        //{
        //    Book PurchasedBook = _bookRepo.GetBookById(id);
        //    int Quantity = 1; //TODO: Get the value from user

        //    CartItem Item = new CartItem();
        //    Item.PurchasedBook = PurchasedBook;
        //    Item.Quantity = Quantity;

        //    var result = _shoppingCartRepository.AddItem(Item);

        //}
        #endregion

    }
}