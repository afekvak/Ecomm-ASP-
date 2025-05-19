using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Users
    {
        public int Uid { get; set; }    
        public string FullName { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string Role { get; set; }

        public static Users GetById(int Uid)
        {
            return UsersDAL.GetById(Uid);
        }

        public static List<Users> GetAll()
        {
            return UsersDAL.GetAll();
        }

        public int Save()
        {
            return UsersDAL.Save(this);
        }

        public static int DeleteById(int Uid)
        {
            return UsersDAL.DeleteById(Uid);
        }


    }
}