using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DAL;
namespace Ecomm.AdminManage
{
    public partial class CategoryAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Cid = Request["Cid"] + ""; // מקבל את מזהה הקטגוריה מהשורת כתובת אם יש
                Categories c = null; // מגדיר משתנה שיחזיק את הקטגוריה

                if (!string.IsNullOrEmpty(Cid)) // אם יש מזהה קטגוריה בכתובת
                {
                    c = Categories.GetById(int.Parse(Cid)); // מביא את הקטגוריה לפי מזהה
                }

                if (c != null) // אם נמצאה קטגוריה לא חדשה
                {
                    TxtPname.Text = c.Cname; // שם הקטגוריה
                    HidCid.Value = c.Cid + ""; // מזהה מוסתר
                }
                else
                {
                    HidCid.Value = "-1"; // קטגוריה חדשה
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            Categories c = new Categories();// מגדיר אובייקט קטגוריה חדש

            c.Cid = int.Parse(HidCid.Value);// מזהה הקטגוריה
            c.Cname = TxtPname.Text;// שם הקטגוריה
            c.ParentCid = int.Parse(TxtParentCid.Text);// מזהה הקטגוריה ההורה

            c.Save();// שומר את הקטגוריה
            Response.Redirect("CategoryList.aspx");// מעביר לדף הקטגוריות
        }
    }
}