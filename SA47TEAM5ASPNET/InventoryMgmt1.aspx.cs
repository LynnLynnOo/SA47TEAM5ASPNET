using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SA47TEAM5ASPNET
{
    public partial class InventoryMgmt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {

            Bookshop context = new Bookshop();
            GridView1.DataSource = context.Book.ToList<Book>();
            GridView1.DataBind();

        }


        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;  // go into edit mode.
            BindGrid();
        }



        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.Rows[e.RowIndex]; // current row under editing;      
                string title = (row.FindControl("TextBox1") as TextBox).Text;
                string author = (row.FindControl("TextBox2") as TextBox).Text;
                string isbn = (row.FindControl("TextBox3") as TextBox).Text;
                decimal price = decimal.Parse((row.FindControl("TextBox4") as TextBox).Text);
                int stock = int.Parse((row.FindControl("TextBox5") as TextBox).Text);


                UpdateBook(title, author, isbn, price, stock);
                GridView1.EditIndex = -1; // exiting from editing. similar to cancel. Change the textbox back to item template
                BindGrid();
            }

            catch
            {
                MessageBox.Show(this, "Invalid data! Please confirm again.");
            }

        }

        //Update/ammend Book Info
        private static void UpdateBook(string title, string author, string isbn, decimal price, int stock)
        {
            Bookshop context = new Bookshop();

            var b = (from x in context.Book where x.ISBN == isbn select x).First();

            b.Title = title;
            b.ISBN = isbn;
            b.Author = author;
            b.Stock = stock;
            b.Price = price;
            context.SaveChanges();

        }


        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        //Search books based on different options Title,Cat,ISBN,Author
        protected void Button1_Click(object sender, EventArgs e)
        {
            Bookshop context = new Bookshop();



            if(optionDropDownList.Text == "Title")

            {
                   var q = from x in context.Book where x.Title.Contains(optionTextBox.Text) select x;
                   GridView1.DataSource = q.ToList();
                   GridView1.DataBind();                
            }

            if (optionDropDownList.Text == "Category")

            {
                var q = (from x in context.Category where x.Name.Contains(optionTextBox.Text) select x.CategoryID).First();
                var r = from x in context.Book where x.CategoryID == q select x;
                GridView1.DataSource = r.ToList();
                GridView1.DataBind();
            }

            if (optionDropDownList.Text == "ISBN")

            {
                var q = from x in context.Book where x.ISBN == optionTextBox.Text select x;
                GridView1.DataSource = q.ToList();
                GridView1.DataBind();
            }

            if (optionDropDownList.Text == "Author")

            {

                var q = from x in context.Book where x.Author.Contains(optionTextBox.Text) select x;
                GridView1.DataSource = q.ToList();
                GridView1.DataBind();

            }
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("InventoryMgmt2.aspx");
        }
    }
}