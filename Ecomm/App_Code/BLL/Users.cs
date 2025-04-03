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
        public string Address { get; set; }
        public string Role { get; set; }

        public static Users GetById(int Uid)
        {
            return UsersDAL.GetById(Uid);
        }

        public static List<Users> GetAll()
        {
            return new List<Users>();
        }

        public int Save()
        {
            return 0;
        }

        public static int DeleteById(int Pid)
        {
            return UsersDAL.DeleteById(Pid);
        }


    }
}