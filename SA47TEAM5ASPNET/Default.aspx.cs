using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA47TEAM5ASPNET
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.Identity.IsAuthenticated && User.IsInRole("Admin"))
            {
                Response.Redirect("InventoryMgmt1");
            }
            if (!IsPostBack)
            {
                using ( Bookshop b = new Bookshop())
                {
                    ListView1.DataSource = b.Book.ToList();      
                    ListView1.DataBind();
                    DropDownList1.DataSource = b.Category.ToList();
                    DropDownList1.DataTextField = "Name";
                    DropDownList1.DataValueField = "CategoryId";
                    DropDownList1.DataBind();
                    DropDownList1.SelectedValue = "6";
                }
            }
            LoadDiscountedPrice();
            LoadCategory();
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ListView1.DataSource = BusinessLogic.SearchCategory(Convert.ToInt32(DropDownList1.SelectedValue), SearchTextBox.Text);
            ListView1.DataBind();
            LoadDiscountedPrice();
            LoadCategory();
        }

        private void LoadDiscountedPrice()
        {
            foreach (ListViewDataItem b in ListView1.Items)
            {
                int bookId = Convert.ToInt32((b.FindControl("IdLabel1") as Label).Text);
                (b.FindControl("IdLabel1") as Label).Visible = false;
                (b.FindControl("PriceLabel2") as Label).Text =  BusinessLogic.GetDiscountedPrice(bookId).ToString("c2");
                (b.FindControl("PriceLabel1") as Label).Text = BusinessLogic.GetPrice(bookId).ToString("c2");
                if (BusinessLogic.GetPrice(bookId) == BusinessLogic.GetDiscountedPrice(bookId))
                {
                    (b.FindControl("PriceLabel2") as Label).Visible = false;
                }
                else
                {
                    (b.FindControl("PriceLabel1") as Label).Text ="<del>" + BusinessLogic.GetPrice(bookId).ToString("c2") + "</del>";
                    (b.FindControl("PriceLabel2") as Label).Text = "&nbsp;&nbsp;" + BusinessLogic.GetDiscountedPrice(bookId).ToString("c2");
                }
            }
        }

        private void LoadCategory()
        {
            foreach(ListViewDataItem b in ListView1.Items)
            {
                using(Bookshop context = new Bookshop())
                {
                    int bookId = Convert.ToInt32((b.FindControl("IdLabel1") as Label).Text);
                    (b.FindControl("CategoryLabel") as Label).Text = context.Book.Single(x => x.BookID == bookId).Category.Name;
                }               
            }
        }
    }
}