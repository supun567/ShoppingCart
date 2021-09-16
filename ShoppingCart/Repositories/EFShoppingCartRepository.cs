using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Data;
using ShoppingCart.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ShoppingCart.Repositories
{
    public class EFShoppingCartRepository 
    {
        private readonly EFContext _dbContext;

        public EFShoppingCartRepository(EFContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        public string ShoppingCartId { get; set; }

        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public void AddItem(Book purchasedBook)
        {
            var shoppingCartItem = _dbContext.ShoppingCartItems.SingleOrDefault(
                s=>s.Book.Id==purchasedBook.Id
                && s.ShoppingCartId==this.ShoppingCartId
                );

            if (shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem
                {
                    ShoppingCartId = this.ShoppingCartId,
                    Book = purchasedBook,
                    UnitPrice = purchasedBook.Price
                };

                _dbContext.ShoppingCartItems.Add(shoppingCartItem);
            }
            _dbContext.SaveChanges();
        }

        public void RemoveItem(Book purchasedBook)
        {
            var shoppingCartItem = _dbContext.ShoppingCartItems.SingleOrDefault(
                s => s.Book.Id == purchasedBook.Id
                && s.ShoppingCartId == this.ShoppingCartId
                );

            if (shoppingCartItem != null)
            {
                _dbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
            _dbContext.SaveChanges();
        }
        public static EFShoppingCartRepository GetShoppingCart(IServiceProvider services)
        {
            ISession session = services
                                .GetRequiredService<IHttpContextAccessor>()
                                .HttpContext.Session;
            string ShoppingCartId = session.GetString("ShoppingCartId") ??Guid.NewGuid().ToString();
            session.SetString("ShoppingCartId", ShoppingCartId);

            var context = services.GetService<EFContext>();
            return new EFShoppingCartRepository(context) {ShoppingCartId =ShoppingCartId };
        }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            this.ShoppingCartItems = _dbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == this.ShoppingCartId)
                .Include(x=>x.Book)
                .ToList();

            return this.ShoppingCartItems;
        }

        public decimal GetShopiingCartTotal()
        {
            return _dbContext.ShoppingCartItems
                .Where(c => c.ShoppingCartId == this.ShoppingCartId)
                .Select(c => c.Book.Price).Sum();
        }

        public void ClearShoppingCart()
        {

            var shoppingCartItems = _dbContext.ShoppingCartItems
                .Where(cart => cart.ShoppingCartId == this.ShoppingCartId);

            _dbContext.ShoppingCartItems.RemoveRange(ShoppingCartItems);
        }
    }
}
