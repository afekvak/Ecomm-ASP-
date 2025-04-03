using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Ecomm.AdminManage
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(sender == null)
            {
                Response.Redirect("/Login.aspx"); // redirect to login page if user is not logged in
            }
            Users us = (Users)Session["user"]; // get the user from the session
        }
    }
}