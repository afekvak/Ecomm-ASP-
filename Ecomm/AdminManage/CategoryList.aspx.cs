using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm.AdminManage
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Categories> lst = Categories.GetAll();

                RptCats.DataSource = lst;//מקשרת את רשימת המוצרים לריפיטר
                RptCats.DataBind();//ממלאת את הריפיטר


            }
        }
    }
}