using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SA47TEAM5ASPNET
{
    public class CartModel
    {
        public CartModel(string Title, decimal Price, int Qty, decimal Discount, decimal Subtotal)
        {
            this.Title = Title;
            this.Price = Price;
            this.Qty = Qty;
            this.Discount = Discount;
            this.Subtotal = Subtotal;
        }

        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Qty { get; set; }
        public decimal Discount { get; set; }
        public decimal Subtotal { get; set; }

    }

    
}