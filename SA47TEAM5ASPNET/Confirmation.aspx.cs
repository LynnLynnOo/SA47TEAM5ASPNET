using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA47TEAM5ASPNET
{
    public partial class Confirmation : System.Web.UI.Page
    {
        List<CartModel> models = new List<CartModel>();
        List<CartItem> items = new List<CartItem>();

        protected void Page_Load(object sender, EventArgs e)
        {
            items = (List<CartItem>)Session["cartItems"];
            if (!IsPostBack)
            {
                if (items.Count <= 0)
                {
                    Response.Redirect("~/");
                }
            }
            if (items.Count <= 0)
            {
                Response.Redirect("~/");
            }

            foreach (var item in items)
            {
                int bookId = BusinessLogic.GetBookID(item.Isbn);
                string title = BusinessLogic.GetBookTitle(bookId);
                int quantity = item.Quantity;
                decimal price = BusinessLogic.GetPrice(bookId);
                decimal discount = (BusinessLogic.GetPrice(bookId) - BusinessLogic.GetDiscountedPrice(bookId)) * quantity;
                decimal subtotal = price * quantity - discount;
                CartModel model = new CartModel(title, price, quantity, discount, subtotal);
                models.Add(model);

            }
            gvCart.DataSource = models;
            gvCart.DataBind();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session["cartItems"] = new List<CartItem>();
            Session["total"] = String.Empty;
            Session["discountTotal"] = String.Empty;
            Session["discountedTotal"] = String.Empty;
            Session["promoCode"] = String.Empty;



        }
    }
}