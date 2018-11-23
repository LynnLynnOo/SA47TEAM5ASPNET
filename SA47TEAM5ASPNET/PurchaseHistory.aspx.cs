using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;

namespace SA47TEAM5ASPNET
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        string customerId;
        protected void Page_Load(object sender, EventArgs e)
        {
            customerId = User.Identity.GetUserId();
            orderDetailsgdv.DataSource = BusinessLogic.GetCustomerOrder(customerId);
            orderDetailsgdv.DataBind();
        }
    }
}