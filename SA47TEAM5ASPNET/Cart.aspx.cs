using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA47TEAM5ASPNET
{
    public partial class Cart : System.Web.UI.Page
    {
        List<Book> lstBooks = new List<Book>();
        List<CartModel> models = new List<CartModel>();
        List<CartItem> items = new List<CartItem>();


        protected void Page_Load(object sender, EventArgs e)
        {
            Session["total"] = String.Empty;
            Session["discountTotal"] = String.Empty;
            Session["discountedTotal"] = String.Empty;
            decimal total = 0;
            string promoCode = (string)Session["promoCode"];

            items = (List<CartItem>)Session["cartItems"];
            if (items.Count <= 0 )
            {
                Response.Redirect("~/");
            }
            else
            {
                foreach (var item in items)
                {
                    int bookId = BusinessLogic.GetBookID(item.Isbn);
                    string title = BusinessLogic.GetBookTitle(bookId);
                    int quantity = item.Quantity;
                    decimal price = BusinessLogic.GetPrice(bookId);
                    decimal discount = (BusinessLogic.GetPrice(bookId) - BusinessLogic.GetDiscountedPrice(bookId)) * quantity;
                    decimal subtotal = price * quantity - discount;
                    total += subtotal;
                    CartModel model = new CartModel(title, price, quantity, discount, subtotal);
                    models.Add(model);
                }
                Session["total"] = total.ToString("c2");
                Session["discountTotal"] = (total - BusinessLogic.GetTotalPromoPriceFromCart(items, promoCode)).ToString("c2");
                Session["discountedTotal"] = BusinessLogic.GetTotalPromoPriceFromCart(items, promoCode).ToString("c2");
                gvCart.DataSource = models;
                gvCart.DataBind();
            }



        }

        protected void Products(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }

        protected void Checkout(object sender, EventArgs e)
        {
            if (BusinessLogic.CheckOut(items, User.Identity.GetUserId(), (string)Session["promoCode"]))
                Response.Redirect("~/Confirmation.aspx");
            else
                lblMsg.Text = "HAHAHA";
        }
        
        

        protected void btnMinus_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int qty = items[row.RowIndex].Quantity - 1;
            if (qty > 0)
            {
                items[row.RowIndex].Quantity -= 1;
                Response.Redirect("~/Cart");
            }
            else
            {

                items.RemoveAt(row.RowIndex);
                if (items.Count > 0)
                {
                    Session["cartItems"] = items;
                    Response.Redirect("~/Cart");
                }
                else
                {
                    Response.Redirect("~/");
                }
            }
        }

        protected void btnPlus_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            int qty = items[row.RowIndex].Quantity + 1;
            if (qty > BusinessLogic.GetQty(BusinessLogic.GetBookID(items[row.RowIndex].Isbn)))
            {
                pnlError.Visible = true;
            }
            else
            {
                items[row.RowIndex].Quantity += 1;
                Session["cartItem"] = items;
                Response.Redirect("~/Cart");
            }



        }

        protected void btnDismiss_Click(object sender, EventArgs e)
        {
            pnlError.Visible = false;
            Response.Redirect("~/Cart");
        }

        protected void btnDiscount_Click(object sender, EventArgs e)
        {
            if (BusinessLogic.CheckPromoCode(txtDiscount.Text))
            {
                pnlPromoCode.Visible = true;
                lblPromoCode.Text = "Discount Code Applied!";
                Session["promoCode"] = txtDiscount.Text;

            }
            else
            {
                pnlPromoCode.Visible = true;
                lblPromoCode.Text = "Invalid Code!";
            }
        }
    }
}