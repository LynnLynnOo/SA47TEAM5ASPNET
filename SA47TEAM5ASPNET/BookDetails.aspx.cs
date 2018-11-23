using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA47TEAM5ASPNET
{
    public partial class BookDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string isbn = Request.QueryString["ISBN"];
            Bookshop context = new Bookshop();

            int bookid = BusinessLogic.GetBookID(isbn);
            if (isbn != null)
            {
                
                string img = context.Book.Single(x => x.BookID == bookid).Image;
                string n = string.Format("~/images/" + img);
                Image1.ImageUrl = n;
                
                Book cn = BusinessLogic.GetBook(isbn);
                
                decimal NormalPrice = BusinessLogic.GetPrice(bookid);
                decimal DiscountedPrice = BusinessLogic.GetDiscountedPrice(bookid);
              
                Title_lbl.Text = cn.Title;
                Author_lbl.Text = cn.Author;
                Category_lbl.Text = BusinessLogic.GetCategoryName(isbn);
                 NormalPrice_lbl.Text = NormalPrice.ToString("c2");
                if (NormalPrice==DiscountedPrice)
                {
                    NormalPrice_lbl.Font.Strikeout = false ;
                    Discounted_lbl.Visible = false;
                }
                else
                { 
                    NormalPrice_lbl.Font.Strikeout = true;
                    Discounted_lbl.Text = BusinessLogic.GetDiscountedPrice(bookid).ToString("c2");
                    Discounted_lbl.Visible = true;
                }

                Warning_lbl.Visible = false;

            }
        }
                 
        //Add book into cart
        protected void AddtoCart_Click(object sender, EventArgs e)
        {
             string isbn = Request.QueryString["ISBN"];
            int quantity = Convert.ToInt32(TextBox1.Text);
            if(quantity!=0)
            {
                int i;
                List<CartItem> Cart = (List<CartItem>)Session["cartItems"];
                int j = Cart.Count;
                for(i=0;i<j;i++)
                {
                    if(Cart[i].Isbn==isbn)
                    { Cart[i].Quantity = Cart[i].Quantity + quantity;
                        Session["cartItems"] = Cart;
                        Response.Redirect("~/Cart");
                    }
                }
                CartItem books = new CartItem(isbn, quantity);
                Cart.Add(books);
                Session["cartItems"] = Cart;
                Response.Redirect("~/Cart");
            }
            else
            {
                Warning_lbl.Visible = true;
                Warning_lbl.Text = "Please select quantity!";
            
            }
            
            
        }

     //Click this button to minus one of the book quantity
        protected void Minus_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TextBox1.Text);
            if(x>0)
            { TextBox1.Text = Convert.ToString(x - 1); }
            else
            {
                Warning_lbl.Visible = true;
                Warning_lbl.Text = "Can not reduce"; }
           
        }
        //Click this button to plus one of the book quantity
        protected void Plus_Click(object sender, EventArgs e)
        {
           // string isbn = "9780060555665";
            string isbn = Request.QueryString["ISBN"];
            Book xy = BusinessLogic.GetBook(isbn);
            int x = Convert.ToInt32(TextBox1.Text);
            if(x<xy.Stock)
            { TextBox1.Text = Convert.ToString(x + 1); }
            else {
                Warning_lbl.Visible = true;
                Warning_lbl.Text = "Out of Stock"; }
        }
    }
}