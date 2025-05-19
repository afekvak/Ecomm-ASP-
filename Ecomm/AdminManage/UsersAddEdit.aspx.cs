using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm.AdminManage
{
    public partial class UsersAddEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // התנאי מתבצע רק בטעינה הראשונה ולא אחרי לחיצה על כפתור
            {
                string Uid = Request["Uid"] + ""; // מקבל את מזהה המוצר מהשורת כתובת אם יש
                Users u = null; // מגדיר משתנה שיחזיק את המוצר

                if (!string.IsNullOrEmpty(Uid)) // אם יש מזהה מוצר בכתובת
                {
                    u = Users.GetById(int.Parse(Uid)); // מביא את המוצר לפי מזהה
                }

                if (u != null) // אם נמצא מוצר (לא חדש)
                {
                    TxtFullName.Text = u.FullName; // ממלא את שם המוצר
                    TxtEmail.Text = u.Email; // ממלא את תיאור המוצר
                    TxtPhone.Text = u.Phone + ""; // ממלא את המחיר
                    TxtAdress.Text = u.Adress; // ממלא את שם הקובץ של התמונה
                    HidUid.Value = u.Uid + ""; // שם את מזהה המוצר בשדה מוסתר
                }
                else
                {
                    HidUid.Value = "-1"; // אם לא נמצא מוצר – נחשב כמוצר חדש
                }
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string uid = HidUid.Value;
            string name = TxtFullName.Text;
            string email = TxtEmail.Text;
            string phone = TxtPhone.Text;
            string adress = TxtAdress.Text;

            Users u = new Users();
            u.Uid = int.Parse(uid);
            u.FullName = name;
            u.Email = email;
            u.Phone = phone;
            u.Adress = adress;

            int res = u.Save();

            if (res > 0)
                Response.Redirect("UsersList.aspx");
        }   

        
    }
}