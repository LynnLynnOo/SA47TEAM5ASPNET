using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA47TEAM5ASPNET
{
    public class CartItem
    {
        public CartItem(string Isbn, int Quantity)
        {
            this.Isbn = Isbn;
            this.Quantity = Quantity;
        }

        public string Isbn { get; set; }
        public int Quantity { get; set; }
        

    }
}