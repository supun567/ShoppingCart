using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoppingCart.Models;


namespace ShoppingCart.Repositories
{
    public interface IShoppingCartRepository
    {
        public EFShoppingCartRepository GetShoppingCart(IServiceProvider services);

        public void AddItem(Book purchasedBook);

        void RemoveItem(Book purchasedBook);

        List<ShoppingCartItem> GetShoppingCartItems();

        decimal GetShopiingCartTotal();

        void ClearShoppingCart();
    }
}
