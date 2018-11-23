using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SA47TEAM5ASPNET
{


    //To show pop up messages
    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "Messagebox",
               "<script language='javascript'>alert('" + Message + "');</script>");
        }
    }
    public partial class InventoryMgmt2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            Bookshop context = new Bookshop();
            var q = from x in context.Category where x.Name != "All" select x.Name;
            catDropDownList.DataSource = q.ToList();
            catDropDownList.DataBind();
            uploadLabel.Visible = false;           
        }

        //Add new book to data base together with photo.
        protected void saveButton_Click(object sender, EventArgs e)
        {

            Bookshop context = new Bookshop();
            //For uploading image
            HttpPostedFile postedFile = FileUpload1.PostedFile;
            string filename = Path.GetFileName(postedFile.FileName);
            string fileExtension = Path.GetExtension(filename);



            if (titleTextBox.Text != "" && isbnTextBox.Text != "" && authorTextBox.Text != "" &&
                stockTextBox.Text != "" && priceTextBox.Text != "")

            {
                if (stockTextBox.Text.Any(char.IsDigit))
                {
                    if (priceTextBox.Text.Any(char.IsDigit))
                    {
                        if (FileUpload1.HasFile)
                        {
                            if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".gif" ||
                            fileExtension.ToLower() == ".png" || fileExtension.ToLower() == ".bmp")
                            {

                                var q = from x in context.Category where x.Name == catDropDownList.Text select x.CategoryID;
                                var r = from y in context.Book where y.ISBN == isbnTextBox.Text select y;


                                if ((from y in context.Book where y.ISBN == isbnTextBox.Text select y).Count() > 0)
                                {
                                    MessageBox.Show(this, "The Book alredy exists!");
                                    
                                }

                                else
                                {
                                    Book b = new Book();
                                    b.Title = titleTextBox.Text;
                                    b.CategoryID = q.First();
                                    b.ISBN = isbnTextBox.Text;
                                    b.Author = authorTextBox.Text;
                                    b.Stock = int.Parse(stockTextBox.Text);
                                    b.Price = decimal.Parse(priceTextBox.Text);
                                    b.Image = isbnTextBox.Text + fileExtension;

                                    context.Book.Add(b);
                                    context.SaveChanges();

                                    FileUpload1.SaveAs(Server.MapPath("images\\" + isbnTextBox.Text + fileExtension));
                                    uploadLabel.Visible = true;
                                    uploadLabel.Text = "A new book entry has been created successfully!";
                                    Image1.ImageUrl = "images\\" + isbnTextBox.Text + fileExtension;
                                }


                            }
                            else
                            {

                                MessageBox.Show(this, "The image must be in one of the following formats:" +
                                                       ".jpp,.gif,.png or.bmp");
                            }
                        }
                        else
                        {
                            MessageBox.Show(this, "Please select an image file!");
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "Price must be digits!");
                    }


                }
                else
                {
                    MessageBox.Show(this, "Stock quantity must be digits!");
                }
            }

            else
            {
                MessageBox.Show(this, "Please fill up all the fields!");
            }

        }
        public void ClearAll()
        {
            titleTextBox.Text = "";
            isbnTextBox.Text = "";
            authorTextBox.Text = "";
            stockTextBox.Text = "";
            priceTextBox.Text = "";
            Image1.ImageUrl = "";   
            Image1.ImageUrl = "";
        }

        protected void cancelButton_Click(object sender, EventArgs e)
        {
            
            ClearAll();
            
        }

        protected void backButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("InventoryMgmt1.aspx");
        }
    }
}