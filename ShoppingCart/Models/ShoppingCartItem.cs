﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingCart.Models
{
    public class ShoppingCartItem
    {

        public int ShoppingCartItemId { get; set; }
                
        public Book Book { get; set; }

        public decimal UnitPrice { get; set; }

        public string ShoppingCartId { get; set; }
    }
}
