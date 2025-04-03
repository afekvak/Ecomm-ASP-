using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace Ecomm
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            List<Users> users = new List<Users>(); // create a list of users
            Users temp; // create a new user
            temp = new Users()
            {
                FullName = "afek",
                Email = "afek@gmail.com",
                Pass = "123",
                Phone = "123456789",
                Address = "empty",
                Role = "admin"
            }; // create a new user

            users.Add(temp); // add the user to the list
            temp = new Users()
            {
                FullName = "afek",
                Email = "afek@gmail.com",
                Pass = "123",
                Phone = "123456789",
                Address = "empty",
                Role = "admin"
            }; // create a new user

            users.Add(temp);
            temp = new Users()
            {
                FullName = "afek",
                Email = "afek@gmail.com",
                Pass = "123",
                Phone = "123456789",
                Address = "empty",
                Role = "admin"
            }; // create a new user

            users.Add(temp);
            temp = new Users()
            {
                FullName = "afek",
                Email = "afek@gmail.com",
                Pass = "123",
                Phone = "123456789",
                Address = "empty",
                Role = "admin"
            }; // create a new user

            users.Add(temp);


            for(int i = 0; i < users.Count; i++)
            {
                if (users[i].Email == TxtEmail.Text && users[i].Pass == TxtPass.Text) // check if the email and password are correct from the list
                {
                    Session["user"] = users[i]; // save the user in the session
                    Response.Redirect("/AdminManage");
                }
                
            }

            Ltlmsg.Text = "Email or Password is incorrect"; // if the email or password is incorrect
        }

        



    }
}