﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ecomm.AdminManage
{
    public partial class ProductAddEdit : System.Web.UI.Page // מחלקה שמייצגת את העמוד ProductAddEdit
    {
        protected void Page_Load(object sender, EventArgs e) // מתבצע בכל טעינת עמוד
        {
            if (!IsPostBack) // התנאי מתבצע רק בטעינה הראשונה ולא אחרי לחיצה על כפתור
            {
                string Pid = Request["Pid"] + ""; // מקבל את מזהה המוצר מהשורת כתובת אם יש
                Product p = null; // מגדיר משתנה שיחזיק את המוצר

                if (!string.IsNullOrEmpty(Pid)) // אם יש מזהה מוצר בכתובת
                {
                    p = Product.GetById(int.Parse(Pid)); // מביא את המוצר לפי מזהה
                }

                // קודם כל ממלא את רשימת הקטגוריות
                List<Categories> LstCat = Categories.GetAll(); // מביא את כל הקטגוריות מהמסד
                DDLCategory.DataSource = LstCat; // קובע את המקור נתונים של ה-DropDown
                DDLCategory.DataValueField = "Cid"; // קובע את השדה שישמש כערך
                DDLCategory.DataTextField = "Cname"; // קובע את השדה שיוצג למשתמש
                DDLCategory.DataBind(); // טוען את הנתונים לרשימה

                if (p != null) // אם נמצא מוצר (לא חדש)
                {
                    TxtPname.Text = p.Pname; // ממלא את שם המוצר
                    TxtPdesc.Text = p.Pdesc; // ממלא את תיאור המוצר
                    TxtPrice.Text = p.Price + ""; // ממלא את המחיר
                    TxtPicname.Text = p.Picname; // ממלא את שם הקובץ של התמונה
                    DDLStatus.SelectedValue = p.Status + ""; // ממלא את הסטטוס של המוצר
                    HidPid.Value = p.Pid + ""; // שם את מזהה המוצר בשדה מוסתר

                    // אם הקטגוריה קיימת ברשימה, קובעת אותה כבחירה
                    if (DDLCategory.Items.FindByValue(p.Cid + "") != null)
                    {
                        DDLCategory.SelectedValue = p.Cid + ""; // בוחר את הקטגוריה של המוצר
                    }
                }
                else
                {
                    HidPid.Value = "-1"; // אם לא נמצא מוצר – נחשב כמוצר חדש
                }
            }



        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string x = GlobFunc.randomString(8); // מייצרת מחרוזת אקראית באורך 8 תווים
            string Picname = " "; // משתנה שיכיל את שם התמונה

            if (UplPic.HasFile)
            {
                // יצירת שם קובץ רנדומלי עם סיומת מקורית (למשל .jpg)
                string FileName = GlobFunc.randomString(6);// מייצרת שם קובץ אקראי באורך 8 תווים
                int ind = UplPic.FileName.LastIndexOf('.');// מחפש את האינדקס של הנקודה האחרונה בשם הקובץ
                string Ext = UplPic.FileName.Substring(ind); // לדוגמה: ".jpg"
                Picname = FileName + Ext;
                UplPic.SaveAs(Server.MapPath("/uploads/prods/img/") + Picname); // שמירת הקובץ לתיקייה בשרת
                TxtPicname.Text = Picname; // ממלא את שם הקובץ בתיבת הטקסט

            }
            Product p = new Product() // יצירת אובייקט חדש של מוצר
            {
                Pid = int.Parse(HidPid.Value), // מזהה המוצר
                Pname = TxtPname.Text, // שם המוצר
                Pdesc = TxtPdesc.Text, // תיאור המוצר
                Price = float.Parse(TxtPrice.Text), // מחיר המוצר
                Picname = TxtPicname.Text, // שם התמונה
                Cid = int.Parse(DDLCategory.SelectedValue), // מזהה הקטגוריה
                Status = DDLStatus.SelectedValue // סטטוס המוצר

            };
            p.Save(); // שומר את המוצר במסד הנתונים
            Response.Redirect("ProductList.aspx"); // מפנה את המשתמש לרשימת המוצרים
        }
    }
}