using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;

namespace SA47TEAM5ASPNET
{
    public partial class PromoConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PromoGridView.DataSource = BusinessLogic.Promos();
                PromoGridView.DataBind();
                DiscountGridView.DataSource = BusinessLogic.CDiscount();
                DiscountGridView.DataBind();
                CategoryDDL.DataSource = BusinessLogic.Cats();
                CategoryDDL.DataTextField = "Name";
                CategoryDDL.DataValueField = "CategoryID";
                CategoryDDL.DataBind();

                

            }
        }
        //Unhide PromoGrid & bind data
        protected void PromoAmend_Click(object sender, EventArgs e)
        {
            PromoGridView.DataSource = BusinessLogic.Promos();
            PromoGridView.DataBind();
            PromoGridView.Visible = true;
        }
        //Unhide DiscountGrid & bind data
        protected void DiscountAmend_Click(object sender, EventArgs e)
        {
            DiscountGridView.DataSource = BusinessLogic.CDiscount();
            DiscountGridView.DataBind();
            DiscountGridView.Visible = true;
        }
        //Add new promotion with exception handling
        protected void AddPromo_Click(object sender, EventArgs e)
        {
            try
            {
                PromoGridView.Visible = false;
                BusinessLogic.CreatePromoCode(PromoTB.Text, short.Parse(PromoDisc.Text), ValidSCal.SelectedDate, Convert.ToInt32(PromoDur.Text));
                Label6.Text = "Promo Created!";
                PromoTB.Text = "";
                PromoDisc.Text = "";
                PromoDur.Text = "";
                PCalVal.Text = "";
            }
            catch (Exception)
            {
                Label6.Text = "Please enter a unique Promo Code";
            }

        }
        //For client data validation purposes
        protected void ValidSCal_SelectionChanged(object sender, EventArgs e)
        {
            PCalVal.Text = ValidSCal.SelectedDate.ToString();
        }

        //Update PromoGridView with exception handling
        protected void UpGV1(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = PromoGridView.Rows[e.RowIndex];

                string promoCode = (row.FindControl("Label1") as Label).Text;
                short discount = short.Parse((row.FindControl("TextBox2") as TextBox).Text);
                DateTime validStart = (row.FindControl("Calendar3") as Calendar).SelectedDate;
                int promoDuration = Convert.ToInt32((row.FindControl("TextBox4") as TextBox).Text);

                BusinessLogic.UpdatePromoCode(promoCode, discount, validStart, promoDuration);
                PromoGridView.EditIndex = -1;

                PromoGridView.DataSource = BusinessLogic.Promos();
                PromoGridView.DataBind();
                Label7.Text = "Update success!";
            }
            catch (Exception)
            {
                Label7.Text = "Please input a valid discount amount and duration.";
            }

        }

        //Edit PromoGridView
        protected void EdGV1(object sender, GridViewEditEventArgs e)
        {
            PromoGridView.EditIndex = e.NewEditIndex;
            PromoGridView.DataSource = BusinessLogic.Promos();
            PromoGridView.DataBind();
        }

        //Cancel edit for PromoGridView
        protected void PromoGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            PromoGridView.EditIndex = -1;
            PromoGridView.DataSource = BusinessLogic.Promos();
            PromoGridView.DataBind();
            Label7.Text = "";
        }
        
        //Edit DiscountGridView
        protected void DiscountGridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            DiscountGridView.EditIndex = e.NewEditIndex;
            DiscountGridView.DataSource = BusinessLogic.CDiscount();
            DiscountGridView.DataBind();
        }

        //Cancel Edit for DiscountGridView
        protected void DiscountGridView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            DiscountGridView.EditIndex = -1;
            DiscountGridView.DataSource = BusinessLogic.CDiscount();
            DiscountGridView.DataBind();
            Label8.Text = "";
        }

        //Update Discounts with exception handling
        protected void DiscountGridView_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = DiscountGridView.Rows[e.RowIndex];
                string discountId = (row.FindControl("Label1") as Label).Text;
                short discountAmt = short.Parse((row.FindControl("TextBox2") as TextBox).Text);
                DateTime validStart = (row.FindControl("Calendar3") as Calendar).SelectedDate;
                int discountDuration = Convert.ToInt32((row.FindControl("TextBox4") as TextBox).Text);
                int catID = Convert.ToInt32((row.FindControl("DDL5") as TextBox).Text);

                BusinessLogic.UpdateCategoryDiscount(discountId, discountAmt, validStart, discountDuration, catID);

                DiscountGridView.EditIndex = -1;

                DiscountGridView.DataSource = BusinessLogic.CDiscount();
                DiscountGridView.DataBind();
                Label8.Text = "Update success!";
            }
            catch (Exception)
            {
                Label8.Text = "Please input a valid discount amount, duration and category.";
                
            }


        } 

        //Add new discounts with exception handling
        protected void AddDiscount_Click(object sender, EventArgs e)
        {
            try { 
                DiscountGridView.Visible = false;
                BusinessLogic.CreateCategoryDiscount(DiscIDTB.Text, short.Parse(CatDisAmt.Text), Calendar3.SelectedDate, Convert.ToInt32(DisDur.Text), Convert.ToInt32(CategoryDDL.SelectedValue));
                DiscLabel.Text = "Promo Created!";
                DiscIDTB.Text = "";
                CatDisAmt.Text = "";
                DisDur.Text = "";
                CategoryDDL.SelectedIndex = 0;
                Calendar3.SelectedDate = DateTime.Today;
                DiscLabel.Text = "Successfully created discount!";
            }
            catch (Exception)
            { DiscLabel.Text = "Please enter a unique DiscountID"; }
            
        }

        //For client data validation purposes.
        protected void Calendar3_SelectionChanged(object sender, EventArgs e)
        {
            DCalVal.Text = Calendar3.SelectedDate.ToShortDateString();
        }




    }
}