using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm.AdminManage
{
    public partial class UsersList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Users> lst = Users.GetAll();

                RptUsers.DataSource = lst;//מקשרת את רשימת המוצרים לריפיטר
                RptUsers.DataBind();//ממלאת את הריפיטר


            }
        }
    }
}